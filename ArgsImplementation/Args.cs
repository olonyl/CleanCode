using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class Args
    {
        private string schema;
        private Dictionary<char, IArgumentMarshaler> marshalers;
        private List<char> argsFound;
        private List<string> currentArgument;
        private List<string> argsList;
        public Args(string schema, string[] args)
        {
            this.schema = schema;
            argsList = args.ToList();
            Parse();
        }

        private void Parse()
        {
            ParseSchema();
            ParseArguments();
        }
        private bool ParseSchema()
        {
            foreach(string element in schema.Split(","))
                if (element.Length > 0)
                    ParseSchemaElement(element.Trim());
            return true;
        }
        private void ParseSchemaElement(string element)
        {
            char elementId = element.ElementAt(0);
            string elementTail = element.Substring(1);
            ValidateSchemaElementId(elementId);
            if (elementTail.Length == 0)
                marshalers.Add(elementId, new BooleanArgumentMarshaler());
            else if (elementTail.Equals("*"))
                marshalers.Add(elementId, new StringArgumentMarshaler());
            else if (elementTail.Equals("#"))
                marshalers.Add(elementId, new IntegerArgumentMarshaler());
            else if (elementTail.Equals("##"))
                marshalers.Add(elementId, new DoubleArgumentMarshaler());
            else if (elementTail.Equals("[*]"))
                marshalers.Add(elementId, new StringArrayArgumentMarshaler());
            else
                throw new ArgsException(ArgsException.ErrorCode.INVALID_ARGUMENT_FORMAT, elementId, elementTail);
        }

        private void ValidateSchemaElementId(char elementId)
        {
            if (!Char.IsLetter(elementId))
                throw new ArgsException(ArgsException.ErrorCode.INVALID_ARGUMENT_NAME, elementId, null);
        }
        private void ParseArguments()
        {
            foreach (var arg in argsList)
                ParseArgument(arg);
        }
        private void ParseArgument(string arg)
        {
            if (arg.StartsWith("-"))
                ParseSchemaElement(arg);
        }
        private void ParseElement(char argChar)
        {
            if (SetArgument(argChar))
                argsFound.Add(argChar);
            else
                throw new ArgsException(ArgsException.ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);
        }
        private bool SetArgument(char argChar)
        {
            IArgumentMarshaler m = marshalers.Where(w=> w.Key == argChar).FirstOrDefault().Value;
            if (m == null)
                return false;
            try
            {
                m.Set(currentArgument);
                return true;
            }
            catch(ArgsException e)
            {
                e.SetErrorArgumentId(argChar);
                throw e;
            }
        }
        public int Cardinality()
        {
            return argsFound.Count;
        }
        public string Usage()
        {
            if (schema.Length > 0)
                return $"-[{schema}]";
            else
                return String.Empty;
        }
        public bool GetBoolean(char arg) 
        {
            IArgumentMarshaler am = marshalers.Where(w => w.Key == arg).FirstOrDefault().Value;
            bool b = false;
            try
            {
                b = am != null && ((BooleanArgumentMarshaler)am).Get();
            }
            catch(Exception e)
            {
                b = false;
            }
            return b;
        }
        public string GetString(char arg)
        {
            IArgumentMarshaler am = marshalers.Where(w => w.Key == arg).FirstOrDefault().Value;
            try
            {
                return am == null? String.Empty : ((StringArgumentMarshaler)am).Get();
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        public int GetInt(char arg)
        {
            IArgumentMarshaler am = marshalers.Where(w => w.Key == arg).FirstOrDefault().Value;
            try
            {
                return am == null ? 0 : ((IntegerArgumentMarshaler)am).Get();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public double GetDouble(char arg)
        {
            IArgumentMarshaler am = marshalers.Where(w => w.Key == arg).FirstOrDefault().Value;
            try
            {
                return am == null ? 0 : ((DoubleArgumentMarshaler)am).Get();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool Has(char arg)
        {
            return argsFound.Contains(arg);
        }
        private void ParseArgumentString(List<string> argsList)
        {
            foreach(var item in argsList)
            {
                string argString = item;
                if (argString.StartsWith("-"))
                    ParseArgumentCharacters(argString.Substring(1));
                else
                    break;
            }
        }

        private void ParseArgumentCharacters(string argChars)
        {
            for (int i = 0; i < argChars.Length; i++)
                ParseArgumentCharacter(argChars.ElementAt(i));
        }

        private void ParseArgumentCharacter(char argChar)
        {
            IArgumentMarshaler m = marshalers.Where(w=> w.Key == argChar).FirstOrDefault().Value;
            if (m == null)
                throw new ArgsException(ArgsException.ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);
            else
                argsFound.Add(argChar);
            try
            {
                m.Set(currentArgument);
            }
            catch(ArgsException e)
            {
                e.SetErrorArgumentId(argChar);
                throw e;
            }
        }

           public int NextArgument()
        {
            return currentArgument.Count;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class Args
    {
        private Dictionary<char, IArgumentMarshaler> marshalers;
        private List<char> argsFound;
        private List<string> currentArgument;
        private const string INVALID_ARGUMENT_FORMAT = "This is an ivalid argument error";
        private const string INVALID_ARGUMENT_NAME = "This is an invalid argument name";
        private const string UNEXPECTED_ARGUMENT = "This is an unexpected argument";
        public Args(string schema, string[] args)
        {
            marshalers = new Dictionary<char, IArgumentMarshaler>();
            argsFound = new List<char>();
            ParseSchema(schema);
            ParseArgumentString(args.ToList());
        }

        private void ParseSchema(string schema)
        {
            foreach(string element in schema.Split(","))
                if (element.Length > 0)
                    ParseSchemaElement(element.Trim());
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
                throw new ArgsException(ErrorCode.INVALID_ARGUMENT_FORMAT, elementId, elementTail);
        }

        private void ValidateSchemaElementId(char elementId)
        {
            if (Char.IsLetter(elementId))
                throw new ArgsException(ErrorCode.INVALID_ARGUMENT_NAME, elementId, null);
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
                throw new ArgsException(ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);
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

        public bool Has(char arg)
        {
            return argsFound.Contains(arg);
        }

        public int NextArgument()
        {
            return currentArgument.Count;
        }

        public bool GetBoolean(char arg)
        {
            return BooleanArgumentMarshaler.GetValue(marshalers.Where(w => w.Key == arg).FirstOrDefault().Value);
        }
    }
}

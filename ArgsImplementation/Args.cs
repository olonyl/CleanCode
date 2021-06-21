using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class Args
    {
        private Dictionary<char, ArgumentMarshaler> marshalers;
        private List<char> argsFound;
        private List<string> currentArgument;
        private const string INVALID_ARGUMENT_FORMAT = "This is an ivalid argument error";
        private const string INVALID_ARGUMENT_NAME = "This is an invalid argumen name";

        public Args(string schema, string[] args)
        {
            marshalers = new Dictionary<char, ArgumentMarshaler>();
            argsFound = new List<char>();
            ParseSchema(schema);
            ParseArgumenString(args.ToList());
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
                throw new ArgsException(INVALID_ARGUMENT_FORMAT, elementId, elementTail);
        }

        private void ValidateSchemaElementId(char elementId)
        {
            if (Char.IsLetter(elementId))
                throw new ArgsException(INVALID_ARGUMENT_NAME, elementId, null);
        }
    }
}

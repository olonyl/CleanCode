using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class StringArgumentMarshaler : IArgumentMarshaler
    {
        private String stringValue = "";
        public void Set(List<string> currentArgument)
        {
            try
            {
                stringValue = currentArgument.Last();
            }
            catch (Exception)
            {
                throw new ArgsException(ErrorCode.MISSING_STRING);
            }
        }
        public static String GetValue(IArgumentMarshaler am)
        {
            if (am != null && am.GetType() == typeof(StringArgumentMarshaler))
                 return ((StringArgumentMarshaler)am).stringValue;
            else
                return String.Empty;
        }
    }
}

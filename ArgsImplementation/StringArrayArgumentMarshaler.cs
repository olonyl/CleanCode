using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class StringArrayArgumentMarshaler : IArgumentMarshaler
    {
        private List<string> stringValue ;
        public void Set(List<string> currentArgument)
        {
            try
            {
                stringValue = currentArgument;
            }
            catch (Exception)
            {
                throw new ArgsException(ErrorCode.MISSING_STRING);
            }
        }
        public static List<string> GetValue(IArgumentMarshaler am)
        {
            if (am != null && am.GetType() == typeof(StringArrayArgumentMarshaler))
                return ((StringArrayArgumentMarshaler)am).stringValue;
            else
                return new List<string>();
        }
    }
}

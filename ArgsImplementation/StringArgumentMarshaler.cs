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
                throw new ArgsException(ArgsException.ErrorCode.MISSING_STRING);
            }
        }
        public String Get()
        {
            return stringValue;
        }
    }
}

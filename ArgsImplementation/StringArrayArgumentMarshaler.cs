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
                throw new ArgsException(ArgsException.ErrorCode.MISSING_STRING);
            }
        }
        public  List<string> Get()
        {
            return stringValue;
        }
    }
}

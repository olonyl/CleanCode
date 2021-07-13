using java.lang;
using java.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class IntegerArgumentMarshaler : IArgumentMarshaler
    {
        private int intValue = 0;
        public void Set(List<string> currentArgument)
        {
            string parameter = null;
            try
            {
                parameter = currentArgument.Last();
                intValue = int.Parse(parameter);
            }
            catch (NoSuchElementException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.MISSING_INTEGER);
            }
            catch (NumberFormatException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.INVALID_INTEGER, parameter);
            }
        }
        public int Get()
        {
            return intValue;
        }
    }
}

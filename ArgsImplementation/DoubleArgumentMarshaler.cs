using java.lang;
using java.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class DoubleArgumentMarshaler : IArgumentMarshaler
    {
        private double doubleValue = 0;
        public void Set(List<string> currentArgument)
        {
            string parameter = null;
            try
            {
                parameter = currentArgument.Last();
                doubleValue = double.Parse(parameter);
            }
            catch (NoSuchElementException e)
            {
                throw new ArgsException(ErrorCode.MISSING_DOUBLE);
            }
            catch (NumberFormatException e)
            {
                throw new ArgsException(ErrorCode.INVALID_DOUBLE, parameter);
            }
        }
        public static double GetValue(IArgumentMarshaler am)
        {
            if (am != null && am.GetType() == typeof(DoubleArgumentMarshaler))
                return ((DoubleArgumentMarshaler)am).doubleValue;
            else
                return 0;
        }
    }
}

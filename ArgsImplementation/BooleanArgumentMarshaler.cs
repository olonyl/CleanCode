using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public class BooleanArgumentMarshaler : IArgumentMarshaler
    {
        private bool booleanValue = false;
        public void Set(List<string> currentArgument)
        {
            booleanValue = true;
        }
        public static bool GetValue(IArgumentMarshaler am)
        {
            if (am != null && am.GetType() == typeof(BooleanArgumentMarshaler))
                return ((BooleanArgumentMarshaler)am).booleanValue;
            else
                return false;
        }
    }
}

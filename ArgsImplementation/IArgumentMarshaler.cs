using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
    public interface IArgumentMarshaler
    {
        void Set(List<String> currentArgument);
    }
}

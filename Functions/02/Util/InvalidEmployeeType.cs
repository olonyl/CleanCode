using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions._02.Util
{
    [Serializable]
    public class InvalidEmployeeType:Exception
    {
        public InvalidEmployeeType(string type):base ($"Ivalid Employee Type: {type}") { }
    }
}

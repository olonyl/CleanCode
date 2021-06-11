using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions._02.Entities
{
    public enum ContractType
    {
        COMMISIONED,
        HOURLY,
        SALARIED
    }
   public class EmployeeRecord
    {
        public ContractType Type { get; set; }
    }
}

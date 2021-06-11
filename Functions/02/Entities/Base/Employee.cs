using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions._02.Entities.Base
{
    public abstract class Employee
    {
        public abstract bool IsPayDay();
        public abstract decimal CalculatePay();
        public abstract void DeliverPay(decimal pay);
        public Employee(EmployeeRecord record)
        {

        }
   
    }

}

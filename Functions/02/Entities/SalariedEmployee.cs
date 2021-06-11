using Functions._02.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions._02.Entities
{
    public class SalariedEmployee : Employee
    {
        public SalariedEmployee(EmployeeRecord record):base(record)
        {

        }
     
        public override decimal CalculatePay()
        {
            throw new NotImplementedException();
        }

        public override void DeliverPay(decimal pay)
        {
            throw new NotImplementedException();
        }

        public override bool IsPayDay()
        {
            throw new NotImplementedException();
        }
    }
}

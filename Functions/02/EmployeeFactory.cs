using Functions._02.Entities;
using Functions._02.Entities.Base;
using Functions._02.Interfaces;
using Functions._02.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions._02
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee MakeEmployee(EmployeeRecord employee)
        {
            switch (employee.Type) 
            {
                case ContractType.COMMISIONED:
                    return new CommissionedEmployee(employee);
                case ContractType.HOURLY:
                    return new HourlyEmployee(employee);
                case ContractType.SALARIED:
                    return new SalariedEmployee(employee);
                default:
                    throw new InvalidEmployeeType(employee.Type.ToString());
            }
        }

    }
}

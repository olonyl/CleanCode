using Functions._02.Entities;
using Functions._02.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions._02.Interfaces
{
    public interface IEmployeeFactory
    {
        public Employee MakeEmployee(EmployeeRecord employee);
    }
}

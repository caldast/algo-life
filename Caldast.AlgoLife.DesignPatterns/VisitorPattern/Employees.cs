using System.Collections.Generic;

namespace Caldast.AlgoLife.DesignPatterns.VisitorPattern
{
    class Employees
    {
        private readonly List<IEmployee> _employees;
        
        public Employees()
        {
            _employees = new List<IEmployee>();
           
        }
        public void Attach(IEmployee employee)
        {
            _employees.Add(employee);
        }
        public void Reject(IEmployee employee)
        {
            _employees.Remove(employee);
        }
        public void Accept(IEmployeeVisitor employeeVisitor)
        {
            foreach (IEmployee employee in _employees)
            {
                employee.Accept(employeeVisitor);
            }
        }

        public IEnumerable<IEmployee> GetEmployees()
        {
            return _employees;
        }
     

        
    }
}

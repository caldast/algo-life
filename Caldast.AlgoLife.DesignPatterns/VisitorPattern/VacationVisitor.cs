namespace Caldast.AlgoLife.DesignPatterns.VisitorPattern
{
    class VacationVisitor : IEmployeeVisitor
    {
        public void Visit(IEmployee employee)
        {  
            employee.VacationDays = employee.VacationDays + 5;
        }
    }
}

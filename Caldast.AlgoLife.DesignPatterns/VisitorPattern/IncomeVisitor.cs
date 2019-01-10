namespace Caldast.AlgoLife.DesignPatterns.VisitorPattern
{
    class IncomeVisitor : IEmployeeVisitor
    {
        public void Visit(IEmployee employee)
        {
            employee.Income = employee.Income * 1.1;          
        }
    }
}

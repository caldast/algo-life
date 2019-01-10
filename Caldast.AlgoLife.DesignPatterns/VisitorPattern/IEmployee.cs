namespace Caldast.AlgoLife.DesignPatterns.VisitorPattern
{
    interface IEmployee
    {
        string Name { get; set; }
        double Income { get; set; }     
        double VacationDays { get; set; }

        void Accept(IEmployeeVisitor visitor);
    }
}

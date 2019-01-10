namespace Caldast.AlgoLife.DesignPatterns.VisitorPattern
{
    class Manager : IEmployee
    {  
        public Manager(string name)
        {
            Name = name;
            Income = 20000;
            VacationDays = 12;
        }

        public string Name
        {
            get;
            set; 
        }
        public double Income { get; set; }
        public double VacationDays { get; set; }

        public void Accept(IEmployeeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

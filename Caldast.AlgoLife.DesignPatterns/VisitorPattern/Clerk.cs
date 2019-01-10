namespace Caldast.AlgoLife.DesignPatterns.VisitorPattern
{
    class Clerk : IEmployee
    {
      

        public Clerk(string name)
        {
            Name = name;
            Income = 10000;
            VacationDays = 10;
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

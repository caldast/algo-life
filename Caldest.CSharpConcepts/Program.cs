using Caldest.CSharpConcepts.LinqToSql;

namespace Caldest.CSharpConcepts
{

    class Program
    {
        static void Main(string[] args)
        {
            var linqToObj = new LinqToObject();
            linqToObj.RemoveOddAndGroupByStateAndByCity();

            var linqToSql = new LinqToSqlRepo();
            linqToSql.PrintAllCoursesAndAssociatedTeacher();



        }
    }
}

using Caldest.CSharpConcepts.LinqToSql;

namespace Caldest.CSharpConcepts
{

    class Program
    {
        static void Main(string[] args)
        {
            var linqToObj = new LinqToObject();
            linqToObj.GroupByAdvanced();

            var linqToSql = new LinqToSqlRepo();
            linqToSql.PrintAllCoursesAndAssociatedTeacher();



        }
    }
}

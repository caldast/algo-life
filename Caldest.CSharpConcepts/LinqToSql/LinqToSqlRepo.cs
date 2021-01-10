using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldest.CSharpConcepts.LinqToSql
{
    class LinqToSqlRepo
    {
        LinqToSql linqToSql = new LinqToSql();

        public void PrintAllCoursesAndAssociatedTeacher()
        {
            //join in linq to sql
            var courseTeacher = from c in linqToSql.Courses
                                join t in linqToSql.Teachers
                                on c.Teacher.Id equals t.Id
                                select new { c.Name, t.FirstName }
                                into ct
                                // no scope of c & t from here
                                let test = ct.Name.Length > 2
                                orderby test
                                select ct; //ct is still in scope 



            foreach (var c in courseTeacher)
            {
                Console.WriteLine($"Course: {c.Name}, Teacher: {c.FirstName}");
            }
        }
    }
}

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
                           select new { c.Name, t.FirstName };


            foreach (var c in courseTeacher)
            {
                Console.WriteLine($"Course: {c.Name}, Teacher: {c.FirstName}");
            }
        }
    }
}

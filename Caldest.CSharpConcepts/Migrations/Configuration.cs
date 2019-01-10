namespace Caldest.CSharpConcepts.Migrations
{
    using Caldest.CSharpConcepts.LinqToSql;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Caldest.CSharpConcepts.LinqToSql.LinqToSql>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Caldest.CSharpConcepts.LinqToSql.LinqToSql context)
        {
            var t1 = new Teacher() { FirstName = "Prof. Buster" };
            var t2 = new Teacher() { FirstName = "Prof. Bumstead" };

            var sc = new Course() { Name = "Science" , Teacher = t1 };
            var alg = new Course() { Name = "Algebra", Teacher = t2 };
            var bio = new Course() { Name = "Biology", Teacher = t1 };
            var ch = new Course() { Name = "Chemistry", Teacher = t2 };

            var s1= new Student() { FirstName = "Sol", LastName = "Barrel" };
            s1.Courses.Add(sc);
            s1.Courses.Add(alg);

            var s2 = new Student() { FirstName = "James", LastName = "Bond" };
            s2.Courses.Add(bio);
            s2.Courses.Add(alg);
            s2.Courses.Add(ch);

            var s3 = new Student() { FirstName = "Harry", LastName = "Smith" };
            s3.Courses.Add(ch);
            s3.Courses.Add(alg);

            var s4 = new Student() { FirstName = "Nancy", LastName = "Dahl" };
            s4.Courses.Add(alg);
            s4.Courses.Add(bio);

            context.Courses.AddOrUpdate(sc,alg,bio,ch);
            
            context.Students.AddOrUpdate(s1, s2,s3,s4);         

        }
    }
}

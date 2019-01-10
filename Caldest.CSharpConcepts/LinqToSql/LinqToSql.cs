using System.Data.Entity;

namespace Caldest.CSharpConcepts.LinqToSql
{
    public class LinqToSql: DbContext
    {
        public LinqToSql() : base("DefaultConnection")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

    }
}

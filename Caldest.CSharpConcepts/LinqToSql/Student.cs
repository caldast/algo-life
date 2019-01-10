using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caldest.CSharpConcepts.LinqToSql
{
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [StringLength(50)]
        public string FirstName { get; set; }
      
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}

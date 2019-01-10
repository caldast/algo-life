using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caldest.CSharpConcepts.LinqToSql
{
    public class Course
    {

        public Course()
        {
            Students = new List<Student>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public int Id { get; set; }


        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Teacher Teacher { get; set; }
    }
}

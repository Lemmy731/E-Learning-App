using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Entity.Models
{
     public class Course: BaseEntity
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Instructor { get; set; }
        public decimal Rating { get; set; }
        public string Image { get; set; }
        public string SubTitle { get; set; }
        public int NumberOfStudents { get; set; }
        public string Language { get; set; } 
        public string Level { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
        public ICollection<Learning> Learnings { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; }
        public DateTime LastUpDated { get; set; } = DateTime.Now;
    }
}

using E_Learn.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Entity
{
    public class Learning
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}

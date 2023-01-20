using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Entity.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }   
        public string Instructor { get; set; }   
        public string Title { get; set; }  
        public float Price { get; set; } 
    }
}

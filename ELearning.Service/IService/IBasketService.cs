using E_Learn.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Service.IService
{
    public interface IBasketService
    {
        void AddCourseItem(Course course);
        public void RemoveCourse(Guid courseId);
    }
}

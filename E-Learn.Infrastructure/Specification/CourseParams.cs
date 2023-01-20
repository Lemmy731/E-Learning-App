using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Specification
{
    public class CourseParams
    {
        public string Sort { get; set; }    
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; } = 1;
        private int MaxPageSize { get; set; } = 20;
        private int _PageSize { get; set; } = 3;
        public int PageSize { get => _PageSize; set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        private string _search;
        public string Search { get => _search; set => _search = value.ToLower(); }
    }
}

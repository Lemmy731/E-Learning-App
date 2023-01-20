using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure
{
    public class ErrorHandle
    {
        private readonly StoreContext _storeContext;

        public ErrorHandle(StoreContext storeContext)
        {
           _storeContext = storeContext;
        }
     
    }
}

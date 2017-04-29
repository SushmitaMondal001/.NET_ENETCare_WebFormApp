using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ENETCareModels
{
    public class MyDbContext: IdentityDbContext
    {
        public MyDbContext(string conString) : base(conString)
        {
        }
    }
}

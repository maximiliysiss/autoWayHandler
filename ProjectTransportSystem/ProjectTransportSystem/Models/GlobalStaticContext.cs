using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models
{
    public class GlobalStaticContext
    {
        public static MainDbContext MainDbContext { get; set; } = new MainDbContext();
    }
}

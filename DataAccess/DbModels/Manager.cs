using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Manager : BaseModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Experience { get; set; }

    }
}

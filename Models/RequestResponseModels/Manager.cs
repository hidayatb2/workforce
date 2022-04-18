using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ManangerRequest
    {
        public Guid Id { get; set; }


        public string Name { get; set; }
    };

    public class ManagerResponse : ManangerRequest
    {

        public string Address { get; set; }

    }
}

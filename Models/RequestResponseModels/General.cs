using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GeneralRequest
    {
        public Guid Id { get; set; }


        public string Name { get; set; }
    };

    public class GeneralResponse : GeneralRequest
    {

        public string Address { get; set; }

        public string UserName { get; set; }

        public BidStatus Status { get; set; }

        public UserRole UserRole { get; set; }

     

    }
}

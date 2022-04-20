using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RequestDb
    {

        public Guid Id { get; set; }


        public Guid CurrentUserId { get; set; }


        public string Name { get; set; }


        public string UserName { get; set; }


        public BidStatus Status { get; set; }


        public string Description { get; set; } 


        public UserRole UserRole { get; set; }

    }

    public class ResponseDb : RequestDb
    {



    }
}

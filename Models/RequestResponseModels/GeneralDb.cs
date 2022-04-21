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


        public Guid SenderId { get; set; }


        public Guid RecieverId { get; set; }


        public string SenderName { get; set; }


        public string RecieverName { get; set; }


        public string SenderUsername { get; set; }


        public string RecieverUsername { get; set; }


        public BidStatus Status { get; set; }


        public string Description { get; set; } 


        public UserRole SenderUserRole { get; set; }


        public UserRole RecieverUserRole { get; set; }

    }

    public class ResponseDb : RequestDb
    {



    }
}

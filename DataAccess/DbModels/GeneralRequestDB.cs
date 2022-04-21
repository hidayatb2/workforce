using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GeneralRequestDB
    {

        public Guid Id { get; set; }


        public string SenderName { get; set; }


        public string RecieverName { get; set; }


        public string SenderUsername { get; set; }


        public string RecieverUsername { get; set; }


        public string Message { get; set; }


        public UserRole SenderRole { get; set; }


        public UserRole RecieverRole { get; set; }


        public BidStatus Status { get; set; }


        public Guid SenderId { get; set; } 


        public Guid RecieverId { get; set; } 


    }
}

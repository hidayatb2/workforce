using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BidRequest
    {
            public Guid Id { get; set; }


            public string BidType { get; set; }


            public string Discription { get; set; }


           public int BidNumber { get; set; } 


            public string BidRate { get; set; }


            public string Address { get; set; }


            public Guid CustomerId { get; set; }


            public BidStatus BidStatus { get; set; }


        }

    public class BidResponse : BidRequest
    {



    }
}


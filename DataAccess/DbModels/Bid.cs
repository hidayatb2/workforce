using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Bid : BaseModel
    {
        public Guid  Id { get; set; }


        public string BidType { get; set; }


        public string Discription { get; set; }


        public int BidNumber { get; set; }


        public string BidRate { get; set; }



        public string Address { get; set; }


        public Guid CustomerId { get; set; }



        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }



        public BidStatus BidStatus { get; set; }



        public ICollection<Participant> Participants { get; set; }
    }
}

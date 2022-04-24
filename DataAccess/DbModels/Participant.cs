using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Participant : BaseModel
    {
        public Guid Id { get; set; }


        public Guid PartcipantId { get; set; }

        [ForeignKey(nameof(PartcipantId))]
        public User User { get; set; }    


        public Guid BidId { get; set; }


        [ForeignKey(nameof(BidId))]
        public Bid Bid { get; set; }


        public string BidRate { get; set; }
    }
}

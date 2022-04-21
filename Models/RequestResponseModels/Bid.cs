using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BidRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "BidType id Required!")]
        public string BidType { get; set; }

        [Required]
        public string Discription { get; set; }


        public int BidNumber { get; set; }


        [Required]
        public string BidRate { get; set; }


        [Required]
        public string Address { get; set; }


        public Guid CustomerId { get; set; }


        public BidStatus BidStatus { get; set; }


    }

    public class BidResponse : BidRequest
    {



    }
}


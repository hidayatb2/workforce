using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Customer:BaseModel,IBaseModel
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Id))]
        public User User { get; set; }


        public string Name { get; set; }


        public Gender Gender { get; set; }


        public string Address { get; set; }


        public string? AdhaarNo { get; set; }


        public string Bank { get; set; }


        public string AccountNo { get; set; }


        public string IFSC { get; set; }

        public ICollection<Bid> Bids { get; set; }

    }
}

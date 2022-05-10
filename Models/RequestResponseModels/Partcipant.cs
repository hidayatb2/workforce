using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PartcipantRequest
    {
        /// <summary>
        /// Id is UserId
        /// </summary>
        public Guid Id { get; set; }


        public Guid BidId { get; set; }


        public Guid PartcipantId { get; set; }

        [Required]
        public string BidRate { get; set; }
    }
}

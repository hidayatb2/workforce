using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactUsRequest
    {
        public Guid Id { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string Message { get; set; }
    }


    public class ContactUsResponse : ContactUsRequest
    {

    }
}

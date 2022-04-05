using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactUsRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }


        public string PhoneNo { get; set; }


        public string Message { get; set; }
    }


    public class ContactUsResponse : ContactUsRequest
    {

    }
}

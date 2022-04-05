using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ContactUs : IBaseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }


        public string PhoneNo { get; set; }


        public string Message { get; set; }
    }
}

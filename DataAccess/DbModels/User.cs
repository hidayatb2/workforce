using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    ///     Admin=1
    ///     Customer=2
    ///     Contractor=3
    ///     Manager=4
    ///     Labour=5
    ///     
    /// </summary>
    public class User :BaseModel
    {
       
        public string UserName { get; set; }


        public string Password { get; set; }

        public string Email { get; set; }


        public string PhoneNo { get; set; }


        public string Salt { get; set; }


        public string ResetCode { get; set; }


        public UserRole UserRole { get; set; }


        public UserStatus UserStatus { get; set; }


        public Customer Customer { get; set; }

        public Contractor Contractor { get; set; }

        public Manager Manager { get; set; }

        public Labour labour { get; set; }


    }
}

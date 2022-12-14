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
    ///     end
    /// </summary>
    public class User : BaseModel , IBaseModel
    {

        public Guid Id { get; set; }

        public string UserName { get; set; }


        public string Name { get; set; }


        public string Password { get; set; }


        public string Email { get; set; }


        public DateTime DOB { get; set; }


        public string PhoneNo { get; set; }


        public string ImagePath { get; set; }


        public string Salt { get; set; }


        public string ResetCode { get; set; }


        public UserRole UserRole { get; set; }


        public UserStatus UserStatus { get; set; }



        public Customer Customer { get; set; }



        public Contractor Contractor { get; set; }



        public Manager Manager { get; set; }



        public Labour Labour { get; set; }



        public ICollection<Participant> Participants { get; set; }



        public SiteWorker SiteWorker { get; set; }
    }
}

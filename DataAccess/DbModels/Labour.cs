using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Labour:BaseModel
    {
        public string Name { get; set; }


        public Gender Gender{ get; set; }


        public DateTime DOB { get; set; }


        public string AdhaarNo { get; set; }


        public string Address1 { get; set; }


        public string Address2 { get; set; }


        public string PhoneNo2 { get; set; }


        public string Bank { get; set; }


        public string AccountNo { get; set; }


        public string IFSC { get; set; }


        public bool IsSkilled { get; set; }


        public ICollection<Skill> Skills { get; set; }


    }
}

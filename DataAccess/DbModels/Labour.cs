using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Labour:UserBaseModel,IBaseModel
    {
        public Guid Id { get; set; }


        [ForeignKey(nameof(Id))]
        public User User { get; set; }


        public string AdhaarNo { get; set; }


        public bool IsSkilled { get; set; }

        
        //public Guid ManagerId { get; set; }


        //[ForeignKey(nameof(ManagerId))]
        //public Manager  Manager { get; set; }

    }
}

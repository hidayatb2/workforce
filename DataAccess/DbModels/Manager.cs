using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Manager : UserBaseModel, IBaseModel
    {
        public Guid Id { get; set; }


        [ForeignKey(nameof(Id))]
        public User User { get; set; }


        public string UserName { get; set; }


        public string AdhaarNo { get; set; }


        public Guid? ContractorId { get; set; }


        [ForeignKey(nameof(ContractorId))]
        public Contractor Contractor { get; set; }

    }
}

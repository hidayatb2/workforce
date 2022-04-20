using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Contractor: UserBaseModel, IBaseModel
    {

        public Guid Id { get; set; }


        [ForeignKey(nameof(Id))]
        public User User { get; set; }


        public string UserName { get; set; }

        public string Title { get; set; }


        public ICollection<Manager> Managers { get; set; }

    }
}

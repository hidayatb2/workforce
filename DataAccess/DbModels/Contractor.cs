using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Contractor:BaseModel,IBaseModel
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Experience { get; set; }


        public string Address { get; set; }


        [ForeignKey(nameof(Id))]
        public User User { get; set; }
    }
}

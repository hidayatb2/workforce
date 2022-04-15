using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Manager : BaseModel , IBaseModel
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Id))]
        public User User { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public int Experience { get; set; }

    }
}

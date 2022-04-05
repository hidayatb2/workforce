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

        public string Address { get; set; }

        public Skill Skill { get; set; }


    }
}

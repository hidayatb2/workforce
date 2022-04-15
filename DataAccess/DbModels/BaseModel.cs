using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseModel
    {
        public Guid CreatedBy { get; set; }


        public DateTime CreatedOn { get; set; }=DateTime.Now;


        public Guid UpdatedBy { get; set; }


        public DateTime UpdatedOn { get; set; }

    }
}

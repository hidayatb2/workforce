using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Slider : IBaseModel

    {
        public Guid Id { get; set; } = new Guid();

        public string Caption { get; set; }

        public string ImagePath { get; set; } 

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        

        

    }
}

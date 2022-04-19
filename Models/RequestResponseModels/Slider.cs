using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SliderRequest
    {


        public Guid Id { get; set; }
       
        [Required]
        public string Caption { get; set; }

        public SliderStatus Slidertatus { get; set; }

        public IFormFile File { get; set; }



    }
    public class SliderResponse : SliderRequest
    {
        public string ImagePath { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestimonialRequest
    {
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string FeedbackMessage { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
        public FeedbackStatus Status { get; set; } 

        public UserRole UserRole { get; set; }

    }


    public class TestimonialResponse : TestimonialRequest
    {

    }
}

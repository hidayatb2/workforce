using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class CustomerManager
    {

        private readonly IRepository repository;


        public CustomerManager(IRepository repository)
        {
            this.repository = repository;
        }

        
        public int Testimonial(TestimonialRequest testimonialRequest)
        {
            Testimonial feedback = new Testimonial()
            {
                Id = testimonialRequest.Id,
                Name = testimonialRequest.Name,
                FeedbackMessage = testimonialRequest.FeedbackMessage,
                status = testimonialRequest.Status,
            };
           return  repository.AddandSave(feedback);
        }

    }
}

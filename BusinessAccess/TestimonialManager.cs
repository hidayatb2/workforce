using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class TestimonialManager
    {
        private readonly IRepository repository;

        public TestimonialManager(IRepository repository)
        {
            this.repository = repository;
        }

        public int Testimonial(TestimonialRequest testimonialRequest)
        {
            Testimonial testimonial = new Testimonial()
            {
                Id = testimonialRequest.Id,
                Name = testimonialRequest.Name,
                FeedbackMessage = testimonialRequest.FeedbackMessage,
                status = testimonialRequest.Status,
                UserRole = testimonialRequest.UserRole,
                
        };
            return repository.AddandSave(testimonial);
        }

        public int Delete(Guid id)
        {
            var x = repository.GetById<Testimonial>(id);
            return repository.Delete(x);
        }

    }
}


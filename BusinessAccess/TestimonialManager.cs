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

        public IEnumerable<TestimonialResponse> GetTestimonials()
        {
            var testimonial =repository.FindBy<Testimonial>(x=>x.status==FeedbackStatus.Approved);
           List<TestimonialResponse> testimonialResponse = new List<TestimonialResponse>();
            TestimonialResponse Tresponse = null;
            foreach (var item in testimonial)
            {
                Tresponse = new TestimonialResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    FeedbackMessage = item.FeedbackMessage,
                    Status = item.status,
                    UserRole = item.UserRole
                };
                testimonialResponse.Add(Tresponse);
            }
            return testimonialResponse;

        }

        public int Testimonial(TestimonialRequest testimonialRequest)
        {
            Testimonial testimonial = new Testimonial()
            {
                Id = testimonialRequest.Id,
                Name = testimonialRequest.Name,
                FeedbackMessage = testimonialRequest.FeedbackMessage,
                status = FeedbackStatus.Hidden,
                UserRole = testimonialRequest.UserRole,
                ImagePath= testimonialRequest.ImagePath,
        };
            return repository.AddandSave(testimonial);
        }

        public int Delete(Guid id)
        {
            var x = repository.GetById<Testimonial>(id);
            return repository.Delete(x);
        }

        public int Update(Guid id)
        {
           var user= repository.FindBy<Testimonial>(x => x.Id == id).FirstOrDefault();
            user.status = FeedbackStatus.Approved;
           return repository.UpdateAndSave<Testimonial>(user);
            

        }

    }
}


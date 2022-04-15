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



        public int Feedback(FeedbackRequest feedbackRequest)
        {
            Feedback feedback = new Feedback()
            {
                Id = feedbackRequest.Id,
                Name = feedbackRequest.Name,
                FeedbackMessage = feedbackRequest.FeedbackMessage,
                status = feedbackRequest.Status,
            };
           return  repository.AddandSave(feedback);
        }

        public int Delete(Guid id)
        {
           var x = repository.GetById<Feedback>(id);
           return repository.Delete(x);
        }

    }
}

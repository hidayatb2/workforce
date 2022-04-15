using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FeedbackRequest
    {
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string FeedbackMessage { get; set; }


        public FeedbackStatus Status { get; set; } 

    }


    public class FeedbackResponse : FeedbackRequest
    {

    }
}

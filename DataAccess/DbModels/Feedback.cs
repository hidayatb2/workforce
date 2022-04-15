using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Feedback : IBaseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FeedbackMessage { get; set; }

        public FeedbackStatus status { get; set; }


    }
}

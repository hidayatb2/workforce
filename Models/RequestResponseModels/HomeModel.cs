using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HomeModel
    {

        public IEnumerable<TestimonialResponse> feedbackResponses { get; set; }

        public IEnumerable<SkillResponse> skillResponses { get; set; }  

    }
}

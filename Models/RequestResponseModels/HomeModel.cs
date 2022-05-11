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


        public IEnumerable<SliderResponse> sliderResponses { get; set; }  

       

    }

    public class GeneralRequestModel
    {
        public IEnumerable<GeneralResponse> generalResponses { get; set; }


        public RequestDb requestDb { get; set; }


        public ResponseDb responseDb { get; set; }


        public string returnValue { get; set; }


        public IEnumerable<UserResponse> userResponses { get; set; }
    }


}

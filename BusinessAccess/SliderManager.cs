

using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class SliderManager
    {
        private readonly IRepository repository;
        //private readonly IMapper mapper;
        public SliderManager(IRepository repository)
        {
            this.repository = repository;
           // this.mapper = mapper;
        }


        //public List<SliderResponse> GetSliders()
        //{
        //    return repository.GetAll<Slider>().ProjectTo<SliderResponse>(mapper.ConfigurationProvider).ToList();
        //}
       
        public IEnumerable<SliderResponse> GetSliders()
        {
            return repository.GetAll<Slider>().Select(x => new SliderResponse
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Caption = x.Caption
            });
            
        }


        public string AddSlider(SliderRequest sliderRequest, string webRootPath)
        {
            if(sliderRequest.File != null)
            {
                Slider slider = new Slider();
                slider.Id = Guid.NewGuid();
                slider.Caption = sliderRequest.Caption;
                slider.ImagePath = FileManager.SaveFile(sliderRequest.File, webRootPath);
                if (repository.AddandSave(slider) > 0)

                    return "SUCCESS";
                else
                   return "There is some Issue in uploading the file please try later";
                
            }
            return "There is some issue please try later";

        }



        public int DeleteSlider(Guid id, string webRootPath)
        {
            var file = repository.GetById<Slider>(id);
            if (file != null)
            {
                if (repository.DeleteAndSave<Slider>(id) > 0)
                {
                    FileManager.DeleteFile(webRootPath, file.ImagePath);
                    return 1;
                }
            }
            return 0;
        }
    }
}

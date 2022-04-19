using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class ContractorManager
    {

        readonly ContractorRepository contractorRepository;

        public ContractorManager(ContractorRepository contractorRepository)
        {
            this.contractorRepository = contractorRepository;
        }

        public IEnumerable<GeneralResponse> GetManagers()
        {
            return contractorRepository.GetAll<Manager>().Select(x=>new GeneralResponse
            {
                Id = x.Id,
                Name = x.Name,
                Address=x.Address,
               

                
            }); 
        }



        public string PostRequest(RequestDb requestDb)
        {

            GeneralRequestDB generalRequestDB = new GeneralRequestDB()
            {
                Id = requestDb.Id,
                Name = requestDb.Name,
                Message = requestDb.Description,
                UserRole = UserRole.Manager,
                CurrentUserId = requestDb.CurrentUserId,
                

            };

            var returnVal= contractorRepository.AddandSave(generalRequestDB);
            if (returnVal != 0)
            {
                return "Success";
            }
            else
            {
                return "Error";
            }

        }

    }
}

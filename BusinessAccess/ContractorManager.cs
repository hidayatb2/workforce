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
            return contractorRepository.GetAll<Manager>().Select(x => new GeneralResponse
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,

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

            var returnVal = contractorRepository.AddandSave(generalRequestDB);
            if (returnVal != 0)
            {
                return "Success";
            }
            else
            {
                return "Error";
            }

        }

        public IEnumerable<ResponseDb> GetRequestMessages(Guid id)
        {

            List<ResponseDb> responseDb = new List<ResponseDb>();
            foreach (var item in contractorRepository.FindBy<GeneralRequestDB>(x=>x.CurrentUserId == id))
            {

                ResponseDb responseDb1 = new ResponseDb();

                responseDb1.Id = item.Id;
                responseDb1.Name = item.Name;
                responseDb1.UserRole = UserRole.Manager;
                responseDb1.CurrentUserId = item.CurrentUserId;
                responseDb1.Description = item.Message;
                responseDb.Add(responseDb1);


            }

           return responseDb;



        }

    }
}

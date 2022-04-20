using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class ManagerRoleManager
    {

        readonly ManagerRepository managerRepository;

        public ManagerRoleManager(ManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }


        public IEnumerable<GeneralResponse> GetContractors()
        {
           return managerRepository.GetAll<Contractor>().Select(x => new GeneralResponse
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
                CurrentUserId=requestDb.CurrentUserId,

            };

            var returnVal = managerRepository.AddandSave(generalRequestDB);
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
            foreach (var item in managerRepository.FindBy<GeneralRequestDB>(x => x.CurrentUserId == id))
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

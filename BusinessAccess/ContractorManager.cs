using DataAccess;
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

        public IEnumerable<Manager> GetManagers()
        {
            return contractorRepository.GetAll<Manager>(); 
        }

    }
}

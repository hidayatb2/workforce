using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContractorRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }

    public class ContractorResponse : ContractorRequest
    {

    }
}

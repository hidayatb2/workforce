using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Site
    {

        public Guid Id { get; set; }


        public string SiteName { get; set; }


        public string SiteAddress { get; set; }


        public ICollection<SiteWorker> SiteWorkers { get; set; }
    }
}

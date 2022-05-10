using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class SiteWorker
    {

        public Guid Id { get; set; }


        public Guid WorkerId { get; set; }


        [ForeignKey(nameof(WorkerId))]
        public User User { get; set; }


        public Guid SiteId { get; set; }


        [ForeignKey(nameof(SiteId))]
        public Site Site { get; set; }
    }
}

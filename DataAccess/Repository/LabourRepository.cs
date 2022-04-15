using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LabourRepository : Repository
    {

        readonly AppDbContext dbContext;

        public LabourRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserResponse GetUserById(Guid id)
        {
            string query = @$"";
            return GetObject<UserResponse>(query);
        }
    }
}

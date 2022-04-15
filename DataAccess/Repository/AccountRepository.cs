using Models;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [ScopedService]
    public class AccountRepository : Repository
    {
        readonly AppDbContext dbContext;

        public AccountRepository(AppDbContext dbContext) : base(dbContext)
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

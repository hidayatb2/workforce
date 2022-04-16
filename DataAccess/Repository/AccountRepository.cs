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


        public UserCompact GetProfile(Guid userId, UserRole userRole)
        {
            if(userRole == UserRole.Labour)
            {
                string query = @$"SELECT U.UserName,U.Email,U.DOB,
                        U.PhoneNo,U.ImagePath,L.AdhaarNo,L.[Name],
                        L.Gender,L.[Address],L.Bank,L.AccountNo,L.IFSC,
                        L.Experience,L.JobProfile,L.WagesType,L.Wages,
                        L.Discription FROM Users U
                        LEFT JOIN Labour L
                        ON U.Id = L.Id
                        Where U.Id = '{userId}' ";
                return GetObject<UserCompact>(query);
            }else if(userRole == UserRole.Manager)
            {

            }else if (userRole == UserRole.Contractor)
            {

            }
            else if (userRole == UserRole.Customer)
            {

            }
            return null;
        }
    }
}

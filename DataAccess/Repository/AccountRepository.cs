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

        public ProfileResponse GetProfile(Guid userId, string userRole)
        {

          if(userRole == "Labour")
            {
                string query = $@"SELECT U.Id, U.UserName,U.Email,U.DOB,
                                U.PhoneNo,U.ImagePath,L.AdhaarNo,L.[Name],
                                L.Gender,L.[Address],L.Bank,L.AccountNo,L.IFSC,
                                L.Experience,L.JobProfile,L.WagesType,L.Wages,
                                L.Discription FROM Users U
                                LEFT JOIN Labour L
                                ON U.Id = L.Id
                                Where U.Id = '{userId}' ";
                return GetObject<ProfileResponse>(query);
            }else if(userRole == "Manager")
            {
                string query = $@"SELECT U.Id, U.UserName,U.Email,U.DOB,
                        U.PhoneNo,U.ImagePath,M.AdhaarNo,M.[Name],
                        M.Gender,M.[Address],M.Bank,M.AccountNo,M.IFSC,
                        M.Experience,M.JobProfile,M.WagesType,M.Wages,
                        M.Discription FROM Users U
                        LEFT JOIN Manager M
                        ON U.Id = M.Id
                        Where U.Id = '{userId}' ";
                return GetObject<ProfileResponse>(query);
            }
            else if (userRole == "Contractor")
            {
                string query = $@"SELECT U.Id, U.UserName,U.Email,U.DOB, AdhaarNo='abc',
                                U.PhoneNo,U.ImagePath,C.[Name],
                                C.Gender,C.[Address],C.Bank,C.AccountNo,C.IFSC,
                                C.Experience,C.JobProfile,C.WagesType,C.Wages,
                                C.Discription FROM Users U
                                LEFT JOIN Contractor C
                                ON U.Id = C.Id
                                Where U.Id = '{userId}' ";
                return GetObject<ProfileResponse>(query);
            }
            else if (userRole == "Customer")
            {
                string query = $@" SELECT U.Id, U.UserName,U.Email,U.DOB,
                        U.PhoneNo,U.ImagePath,
                        C.Gender,C.[Address],C.Bank,C.AccountNo,C.IFSC
                        FROM Users U
                        LEFT JOIN Customer C
                        ON U.Id = C.Id 
                        Where U.Id =  '{userId}' ";
                return GetObject<ProfileResponse>(query);
            }
            return null;
        }

        public int UpdateLabourDetails(ProfileResponse profileResponse)
        {
            string query = $@"UPDATE Labour SET AdhaarNo='{profileResponse.AdhaarNo}' , Name='{profileResponse.Name}', Address='{profileResponse.Address}',
                                Bank='{profileResponse.Bank}', AccountNo='{profileResponse.AccountNo}', 
                                IFSC='{profileResponse.IFSC}',JobProfile='{profileResponse.JobProfile}',Experience='{profileResponse.Experience}',Discription='{profileResponse.Discription}'
                              where id ='{profileResponse.Id}' ";
            var result = ExecuteQuery(query);

            return result;
        }
        public int UpdateManagerDetails(ProfileResponse profileResponse)
        {
            string query = $@"UPDATE Manager SET AdhaarNo='{profileResponse.AdhaarNo}' , Name='{profileResponse.Name}', Address='{profileResponse.Address}',
                                Bank='{profileResponse.Bank}', AccountNo='{profileResponse.AccountNo}', 
                                IFSC='{profileResponse.IFSC}',JobProfile='{profileResponse.JobProfile}',Experience='{profileResponse.Experience}',Discription='{profileResponse.Discription}'
                              where id ='{profileResponse.Id}' ";
            var result = ExecuteQuery(query);

            return result;
        }
        public int UpdateContractorDetails(ProfileResponse profileResponse)
        {
            string query = $@"UPDATE Contractor SET Name='{profileResponse.Name}', Address='{profileResponse.Address}',
                                Bank='{profileResponse.Bank}', AccountNo='{profileResponse.AccountNo}', 
                                IFSC='{profileResponse.IFSC}',JobProfile='{profileResponse.JobProfile}',
                                Experience='{profileResponse.Experience}',Discription='{profileResponse.Discription}'
                              where id ='{profileResponse.Id}' ";
            var result = ExecuteQuery(query);

            return result;
        }
        //public int UpdateCustomerDetails(ProfileResponse profileResponse)
        //{
        //    string query = $@"UPDATE Customer SET AdhaarNo='{profileResponse.AdhaarNo}' , Name='{profileResponse.Name}', Address='{profileResponse.Address}',
        //                        Bank='{profileResponse.Bank}', AccountNo='{profileResponse.AccountNo}', 
        //                        IFSC='{profileResponse.IFSC}',JobProfile='{profileResponse.JobProfile}',Experience='{profileResponse.Experience}',Discription='{profileResponse.Discription}'
        //                      where id ='{profileResponse.Id}' ";
        //    var result = ExecuteQuery(query);

        //    return result;
        //}
    }
}

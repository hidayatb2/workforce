using DataAccess;
using Models;

namespace BusinessAccess
{
    public class AccountManager
    {
        private readonly IRepository repository;

        public AccountManager(IRepository repository)
        {
            this.repository = repository;
        }

        public int Add(UserRequest userRequest)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = userRequest.UserName,
                Salt = AppEncryption.CreateSalt(),
                PhoneNo = userRequest.PhoneNo,
                Email = userRequest.Email,
            };
            user.Password = AppEncryption.CreatePasswordHash(userRequest.Password,user.Salt);
            return repository.AddandSave(user);
        }
    }
}
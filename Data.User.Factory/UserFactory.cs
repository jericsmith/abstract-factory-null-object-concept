using System;
using Data.Users;
using Data.Users.Concrete;

namespace Data.User.Factory
{
    public class UserFactory : IFactory
    {

        public IUserRepository CreateUserRepository()
        {
            return new UserRepository();
        }

        public IUser CreateUser(string password, string userName, string fullName)
        {
            return new Users.Concrete.User()
            {
                UserId = Guid.NewGuid(),
                Password = password,
                Username = userName,
                FullNmae = fullName
            };
        }
    }
}

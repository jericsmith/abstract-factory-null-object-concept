using System;
using Data.Users;
using Data.Users.Concrete;
// TODO - use stub instead of NullUser - initial proof of concept

namespace Data.Factory.Abstract.Alt
{
    public class NullFactory : IFactory
    {
        public IUser CreateUser(string password, string userName, string fullName)
        {
            return new NullUser();
        }

        public IUserRepository CreateUserRepository()
        {
            return new NUllRepository();
        }
    }
    
}

    public class NUllRepository : IUserRepository
    {
        public IUser GetById(Guid userId)
        {
            return new NullUser();
        }

        public IUser GetByUsername(string userName)
        {
        return new NullUser();
    }

        public void Save(IUser user)
        {
           // do nothing;
        }
    }
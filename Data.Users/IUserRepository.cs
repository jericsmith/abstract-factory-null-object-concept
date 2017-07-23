using System;

namespace Data.Users
{
    public interface IUserRepository
    {
        IUser GetById(Guid userId);
        IUser GetByUsername(string userName);

        void Save(IUser user);
    }
}
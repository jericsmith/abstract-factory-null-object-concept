using System;
using System.Security;

namespace Data.Users.Tests
{
    public class ConcreteFactory : IFactory
    {
        public IUser CreateUser(string password, string userName, string fullName)
        {
            return new ConcreteUser(Guid.NewGuid(), userName){Password = password, FullNmae = fullName};
        }

        public IUserRepository CreateUserRepository()
        {
            return new ConcreteUserRepository();
        }
    }

    public class ConcreteUserRepository : IUserRepository
    {
        public IUser GetById(Guid userId)
        {
            return new ConcreteUser(userId);
        }

        public IUser GetByUsername(string userName)
        {
            return new ConcreteUser(Guid.NewGuid(), userName);
        }

        public void Save(IUser user)
        {
            // do nothing
        }
    }

    public class ConcreteUser : IUser
    {
        public ConcreteUser(Guid userId, string userName = "")
        {
            _userId = userId;
            _userName = userName;
        }

        private string _fullName;

        public string FullNmae
        {
            get
            {
                if(_fullName.Trim().Length==0) _fullName = "ConcreteFullName";
                return _fullName;
            }
            set => _fullName = value;
        }

        private string _password;

        public string Password
        {
            get
            {
                if (_password.Trim().Length == 0) _password = "ConcretePassword";
                return _password;
            }
            set => _password = value;
        }

        private Guid _userId;

        public Guid UserId
        {
            get
            {
                if (_userId == Guid.Empty) _userId = Guid.NewGuid();
                return _userId;
            }
            set => _userId = value;
        }

        private string _userName;

        public string Username
        {
            get
            {
                if (_userName.Trim().Length == 0) _userName = "ConcreteUserName";
                return _userName;
            }
            set => _userName = value;
        }

        public void IncrementSessionTicket()
        {
            // do nothing
        }
    }
}
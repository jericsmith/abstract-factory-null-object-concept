using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Data.Users.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly List<IUser> _database;

        public UserRepository()
        {
            _database = new List<IUser>();
            InitUsers();
        }
        public IUser GetById(Guid userId)
        {
            var user = _database.FirstOrDefault(u => u.UserId == userId);
            return user ?? new NullUser();
        }

        public IUser GetByUsername(string userName)
        {
            var user = _database.FirstOrDefault(u => u.Username.Equals(userName));
            return user ?? new NullUser();
        }


        private void InitUsers()
        {
            if (_database.Count != 0) return;

            var users = new User[]
            {
                new User {Password = "kl;djioaepurio;ji;2230", UserId = Guid.NewGuid(), Username = "ribbitter245", FullNmae = "Thurston Powell"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "willywanker", FullNmae = "William Whittaker"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "zachariamiddleton", FullNmae = "Zack Middleton"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "speedygonzalez", FullNmae = "Hector Gonzalez"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "mikeandike", FullNmae = "Michael Ikers"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "samhouston", FullNmae = "Sam Houston"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "jankyjenkins", FullNmae = "Jennifer Jenkins"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "lankylinda", FullNmae = "Linda Lankford"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "whiskers", FullNmae = "Henrietta Plankton"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "fluckmuckin", FullNmae = "Freda March"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "sandstorm", FullNmae = "Sandy Storm"},
                new User {Password = "l;kj;j9020jk;nkw0", UserId = Guid.NewGuid(), Username = "puttymix", FullNmae = "Pug Mixer"},
            };
            _database.AddRange(users);
        }

        public void Save(IUser user)
        {
            var existing = GetById(user.UserId);
            if (existing != null)
            {
                _database.Remove(existing);
            }
            _database.Add(user);
        }

        
    }
}

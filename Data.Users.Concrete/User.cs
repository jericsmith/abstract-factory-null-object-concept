using System;

namespace Data.Users.Concrete
{
    public class User : IUser
    {
        private DateTime _sessionExpiry = DateTime.Now.AddHours(1);
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public void IncrementSessionTicket()
        {
            _sessionExpiry = DateTime.Now.AddHours(1);
        }

        public string FullNmae { get; set; }
        public User()
        {
            
        }
    }
}
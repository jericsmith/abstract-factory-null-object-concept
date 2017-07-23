using System;

namespace Data.Users.Concrete
{
    public class NullUser: IUser
    {
        public string FullNmae { get { return "unknown"; } set { /*do nothing*/ } }
        public string Password { get { return "unknown"; } set { /*do nothing*/ } }
        public Guid UserId { get { return Guid.Empty; } set { /*do nothing*/ } }
        public string Username { get { return "unknown"; } set { /*do nothing*/ } }
        public void IncrementSessionTicket()
        {
            // do nothing
        }
    }
}
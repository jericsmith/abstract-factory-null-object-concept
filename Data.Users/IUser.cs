using System;

namespace Data.Users
{
    public interface IUser
    {
        string FullNmae { get; set; }
        string Password { get; set; }
        Guid UserId { get; set; }
        string Username { get; set; }

        void IncrementSessionTicket();
    }
}
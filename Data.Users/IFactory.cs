namespace Data.Users
{
    public interface IFactory
    {
        IUser CreateUser(string password, string userName, string fullName);
        IUserRepository CreateUserRepository();
    }
}
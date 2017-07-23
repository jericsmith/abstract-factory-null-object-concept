using System;
using Data.Factory.Abstract;
using Data.Users;

namespace NullObjectPattern
{
    internal class Program
    {

        private static readonly IFactory UserFactory;

        static Program()
        {
            UserFactory = UserFactory.CreateUserFactory();
        }
        private static void Main()
        {
            var repository = UserFactory.CreateUserRepository();
            var user = repository.GetByUsername("nonexistent");
            // without the NullUser pattern this would throw an exception
            user.IncrementSessionTicket();

            Console.WriteLine($"The user's full name is {user.FullNmae}");
            Console.ReadKey();
        }
    }
}

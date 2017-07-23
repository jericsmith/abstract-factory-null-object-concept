using System;
using System.Runtime.InteropServices.ComTypes;
using Data.Factory.Abstract.Alt;
using Data.User.Factory;
using Data.Users;

namespace Data.Factory.Abstract
{
    public static class FactoryExtensions
    {
        public static IFactory CreateUserFactory(this IFactory source)
        {
            return source.CreateFactory<UserFactory>();
        }

        public static IFactory CreateNullFactory(this IFactory source)
        {
            return source.CreateFactory<NullFactory>();
        }

        public static T CreateFactory<T>(this IFactory source)
            where T: IFactory, new()
        {
            return new T();
        }


    }
}
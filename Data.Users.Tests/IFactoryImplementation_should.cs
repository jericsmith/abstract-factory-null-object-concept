using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Data.Users.Tests
{
    [TestFixture]
    public class IFactoryImplementation_should
    {
        [Test]
        public void return_a_valid_ifactory_implementation()
        {
            var factory = new Mock<IFactory>();

            Assert.IsNotNull(factory);
        }

        [Test]
        public void return_a_valid_iuserrepository_from_the_createuserrepository_method()
        {
            var factory = new Mock<IFactory>();
            var repository = new Mock<IUserRepository>();

            factory.Setup(meth => meth.CreateUserRepository()).Returns(repository.Object);

            Assert.IsNotNull(factory.Object.CreateUserRepository());
        }
    }
}

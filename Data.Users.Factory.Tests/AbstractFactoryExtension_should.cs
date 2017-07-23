using System;
using Data.Factory.Abstract;
using Data.Factory.Abstract.Alt;
using Moq;
using NUnit.Framework;

namespace Data.Users.Tests
{
    [TestFixture]
    public class AbstractFactoryExtension_should
    {
        [Test]
        public void return_a_valid_ifactory_implementation_with_no_ifactory_implemetation_dependency_reference()
        {
            IFactory factory = null;

            factory = factory.CreateUserFactory();
            IUserRepository repository = factory.CreateUserRepository();
            Assert.IsNotNull(repository);
        }

       
        [Test]
        public void be_able_to_mock_the_concrete_implementations_without_issue()
        {
            var userId = Guid.NewGuid();
            var mockedIFactory = new Mock<IFactory>();
            var mockedIUserRepository = new Mock<IUserRepository>();
            var mockedIUser = new Mock<IUser>();
            mockedIUser.SetupGet(prop => prop.FullNmae).Returns("Winston Churchill");
            mockedIUserRepository.Setup(meth => meth.GetById(userId)).Returns(mockedIUser.Object);
            mockedIFactory.Setup(meth => meth.CreateUserRepository()).Returns(mockedIUserRepository.Object);

            IUserRepository repo = mockedIFactory.Object.CreateUserRepository();
            Assert.IsNotNull(repo);
            IUser user = repo.GetById(userId);
            Assert.IsNotNull(user);

            Assert.AreEqual("Winston Churchill", user.FullNmae);
        }

        [Test]
        public void be_able_to_test_against_stub_concrete_implementations()
        {
            var userId = Guid.NewGuid();
            var password = "Secret Password";
            var userName = "testtill";
            var fullName = "Mr Test Till";

            IFactory factory = null;
            factory = factory.CreateFactory<ConcreteFactory>();

            Assert.IsNotNull(factory);
            IUserRepository repository = factory.CreateUserRepository();
            Assert.IsNotNull(repository);
            IUser user = factory.CreateUser(password, userName, fullName);
            Assert.IsNotNull(user);

            //user.UserId = userId;

            Assert.AreEqual(password, user.Password);
            Assert.IsTrue(user.UserId != Guid.Empty);
            Assert.AreNotEqual(user.UserId, userId);
            user = repository.GetById(userId);
            Assert.AreEqual(user.UserId, userId);
        }

        [Test]
        public void test_this()
        {
            IFactory factory = null;
            factory = factory.CreateNullFactory();
            Assert.IsNotNull(factory);
            var user = factory.CreateUser("pwd", "uname", "fullname");
            Assert.AreEqual(user.FullNmae,"unknown");
        }
        
    }
}

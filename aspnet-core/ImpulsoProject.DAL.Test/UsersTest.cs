using System;
using NUnit.Framework;
using AutoFixture;
using ImpulsoProject.Users.Dto;
using ImpulsoProject.Users;

namespace ImpulsoProject.DAL.Test
{
    [TestFixture]
    public class UsersTest
    {
        Users _users;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _users = new Users();
            _fixture = new Fixture();
        }

        [Test]
        public void AdicionarUserTest()
        {
            var user = _fixture.Create<CreateUserDto>();
            _users.CreateUserTest(user);

            Assert.True(true);
        }

        [TearDown]
        public void TearDown()
        {
            _users = null;
            _fixture = null;
        }
    }
}

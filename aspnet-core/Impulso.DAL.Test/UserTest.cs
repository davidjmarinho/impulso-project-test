using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoFixture;

namespace Impulso.DAL.Test
{
    [TestFixture]
    public class UserTest
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
        public void GetUserTest()
        {
            var user = _fixture.Create<User>();
            User userResult;
        }


        [TearDown]
        public void TearDown()
        {
            _users = null;
            _fixture = null;
        }

    }
}

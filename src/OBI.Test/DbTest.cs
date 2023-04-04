using Microsoft.EntityFrameworkCore;
using OBI.Business.Models;
using OBI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBI.Test
{
    public class DbTest
    {
        private static DbContextOptions<UserRepository> options = new DbContextOptionsBuilder<UserRepository>()
            .UseInMemoryDatabase(databaseName: "UserDbTest")
            .Options;

        UserRepository context;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new UserRepository(options);
            context.Database.EnsureCreated();

            SeedDatabase();
        }

        [Test, Order(1)]
        public void GetAllUsers()
        {
            var result = context.Users.ToList();

            Assert.That(result.Count, Is.EqualTo(3));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "User1"
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "User2"
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "User3"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

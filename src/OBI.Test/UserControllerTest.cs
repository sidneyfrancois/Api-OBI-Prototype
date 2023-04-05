using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBI.Api.Controllers;
using OBI.Business.Models;
using OBI.Data.Context;

namespace OBI.Test
{
    internal class UserControllerTest
    {
        private static DbContextOptions<MyDbContext> options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "UserDbControllerTest")
            .Options;

        MyDbContext context;
        UserController userController;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new MyDbContext(options);
            context.Database.EnsureCreated();

            SeedDataBase();

            userController = new UserController();
        }

        [Test, Order(1)]
        public void ControllerGetAllUsers()
        {
            IActionResult actionResult = userController.GetAllUsers(context);
            Assert.That(actionResult, Is.TypeOf<OkObjectResult>());
            var actionResultData = (actionResult as OkObjectResult).Value as List<User>;
            TestContext.Out.WriteLine(actionResultData);
            TestContext.Out.WriteLine(string.Format("members of Users: ({0}).", string.Join(", ", actionResultData.Select(u => u.Name))));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDataBase()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sidney"
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pedro"
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Lucas"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

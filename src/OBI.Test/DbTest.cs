using Microsoft.EntityFrameworkCore;
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
        private static DbContextOptions<UserRepository> dbContextOptions = new DbContextOptionsBuilder<UserRepository>()
            .UseInMemoryDatabase(databaseName: "UserDbTest")
            .Options;

        UserRepository context;

        [OneTimeSetUp]
        public void Setup()
        {

        }
    }
}

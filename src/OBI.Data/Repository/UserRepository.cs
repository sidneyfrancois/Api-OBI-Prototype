using Microsoft.EntityFrameworkCore;
using OBI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBI.Data.Repository
{
    public class UserRepository : DbContext
    {
        public UserRepository(DbContextOptions<UserRepository> options) 
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
    }
}

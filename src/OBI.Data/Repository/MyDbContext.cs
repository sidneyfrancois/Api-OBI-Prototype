using Microsoft.EntityFrameworkCore;
using OBI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBI.Data.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) 
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Models.Course> Courses { get; set; }
        public DbSet<Models.Teacher> Teachers { get; set; }
        public DbSet<Models.Student> Students { get; set; }

    }
}

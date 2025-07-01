using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class TrainingDbContext : DbContext
    {
        private readonly string connectionString;
        public TrainingDbContext()
        {
            connectionString = "Server = MY-WEAPON\\SQLEXPRESS; Database = Csharpb20; User Id = csharpb20; Password = 123456; Trust Server Certificate = true;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}

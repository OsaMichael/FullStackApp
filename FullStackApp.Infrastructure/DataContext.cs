using FullStackApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data")
        {
            Database.SetInitializer<DataContext>(null); // This is added to prevent recreating existing database
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }


        //public static DataContext Create()
        //{
        //    return new DataContext();
        //}
    }
}

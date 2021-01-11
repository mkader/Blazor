using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCRUD.Models;

namespace CustomerCRUD.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Seed Stores Table
            modelBuilder.Entity<Store>().HasData(
                new Store { StoreID = 1, StoreName = "TXIRV" });
            modelBuilder.Entity<Store>().HasData(
                new Store { StoreID = 2, StoreName = "WIMAD" });
            modelBuilder.Entity<Store>().HasData(
                new Store { StoreID = 3, StoreName = "NEBEL" });
            modelBuilder.Entity<Store>().HasData(
                new Store { StoreID = 4, StoreName = "TXDFW" });

            // Seed Customer Table

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 100,
                FirstName = "Bugs",
                LastName = "Bunny",
                Email = "Bugs.Bunny@dns.com",
                DateOfJoin = new DateTime(1980, 10, 5),
                MemberType = MemberType.Gold,
                StoreID = 1,
                //Store = new Store { StoreID = 1, StoreName = "TXIRV" },
                Image = "images/bugs.png"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 200,
                FirstName = "Winnie",
                LastName = "Pooh",
                Email = "Winnie.Pooh@dns.com",
                DateOfJoin = new DateTime(1981, 12, 22),
                MemberType = MemberType.Silver,
                //Store = new Store { StoreID = 2, StoreName = "WIMAD" },
                StoreID = 2,
                Image = "images/winnie.png"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 300,
                FirstName = "Mickey",
                LastName = "Mouse",
                Email = "Mickey.Mouse@dns.com",
                DateOfJoin = new DateTime(1979, 11, 11),
                MemberType = MemberType.Bronze,
                //Store = new Store { StoreID = 3, StoreName = "NEBEL" },
                StoreID = 3,
                Image = "images/mickey.png"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 400,
                FirstName = "Donald",
                LastName = "Duck",
                Email = "Donald.Duck@dns.com",
                DateOfJoin = new DateTime(1982, 9, 23),
                MemberType = MemberType.Gold,
                //Store = new Store { StoreID = 3, StoreName = "TXDFW" },
                StoreID = 4,
                Image = "images/donald.png"
            });
        }
    }
}

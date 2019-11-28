using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace CombinedElementsLesson
{
    public class TraderContext : DbContext
    {
        public TraderContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=A-104-09;Database=TraderDb;Trusted_Connection=true;").UseLazyLoadingProxies();
        }
        public DbSet<Company> GetCompanies { get; set; }
        public DbSet<PriceHistory> GetPriceHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var firstcompany = new Company
            {
                Name = "apple"
            };
            var secondcompany = new Company
            {
                Name = "samsun"
            };
            var priceHistory1 = new PriceHistory
            {
                CompanyId = firstcompany.Id,
                Date = DateTime.Now,
                Price = 4,
            };
            var priceHistory2 = new PriceHistory
            {
                CompanyId = secondcompany.Id,
                Date = DateTime.Now,
                Price = 800,
            };
            var priceHistory3 = new PriceHistory
            {
                CompanyId = firstcompany.Id,
                Date = DateTime.Now,
                Price = 200,
            };
            var priceHistory4 = new PriceHistory
            {
                CompanyId = firstcompany.Id,
                Date = DateTime.Now,
                Price = 100,
            };
            var priceHistory5 = new PriceHistory
            {
                CompanyId = firstcompany.Id,
                Date = DateTime.Now,
                Price = 100,
            };
            var priceHistory6 = new PriceHistory
            {
                CompanyId = firstcompany.Id,
                Date = DateTime.Now,
                Price = 6000,
            };
            modelBuilder.Entity<Company>().HasData(firstcompany);
            modelBuilder.Entity<Company>().HasData(secondcompany);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory1);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory2);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory3);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory4);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory5);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory6);
        }
    }
}

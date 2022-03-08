using Microsoft.EntityFrameworkCore;
using System;

namespace GBCSporting2021_ACH.Models
{
    public class SportingContext : DbContext
    {
        public SportingContext(DbContextOptions<SportingContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Code = "TRNY10", Name = "Tournament Master 1.0", Price = (decimal)4.99, DateReleased = new DateTime(2015, 12, 1) },
                new Product { ProductID = 2, Code = "LEAG10", Name = "League Scheduler 1.0", Price = (decimal)4.99, DateReleased = new DateTime(2016, 5, 1) },
                new Product { ProductID = 3, Code = "LEAGD10", Name = "League Scheduler Deluxe 1.0", Price = (decimal)7.99, DateReleased = new DateTime(2016, 8, 1) },
                new Product { ProductID = 4, Code = "DRAFT10", Name = "Draft Master 1.0", Price = (decimal)4.99, DateReleased = new DateTime(2017, 2, 1) },
                new Product { ProductID = 5, Code = "TEAM10", Name = "Team Manager 1.0", Price = (decimal)4.99, DateReleased = new DateTime(2017, 5, 1) },
                new Product { ProductID = 6, Code = "TRNY20", Name = "Tournament Master 2.0", Price = (decimal)5.99, DateReleased = new DateTime(2018, 2, 15) },
                new Product { ProductID = 7, Code = "DRAFT20", Name = "Draft Master 2.0", Price = (decimal)5.99, DateReleased = new DateTime(2019, 7, 15) }
            );

            modelBuilder.Entity<Technician>().HasData(
                new Technician { TechnicianID = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", Phone = "800-555-0443"},
                new Technician { TechnicianID = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", Phone = "800-555-0449" },
                new Technician { TechnicianID = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", Phone = "800-555-0459" },
                new Technician { TechnicianID = 4, Name = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", Phone = "800-555-0400" },
                new Technician { TechnicianID = 5, Name = "Jason Lee", Email = "jason@sportsprosoftware.com", Phone = "800-555-0444" }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = 1, Name = "United States of America"},
                new Country { CountryID = 2, Name = "Canada"},
                new Country { CountryID = 3, Name = "South Korea"}
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FirstName = "Kaitlyn", LastName = "Anthoni", Address = "123 Main street", City = "San Francisco", State = "California", PostalCode = "94016", CountryID = 1, Email = "kanthoni@pge.com", Phone = "144-125-1251"}
            );

            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.CustomerID, r.ProductID });
        }
    }
}

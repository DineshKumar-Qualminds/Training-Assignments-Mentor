using Microsoft.EntityFrameworkCore;
using GeographicDataAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GeographicDataAPI.Data
{
    public class GeographicDbContext : DbContext
    {
        public GeographicDbContext(DbContextOptions<GeographicDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.States)
                .WithOne(s => s.Country)
                .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<State>()
                .HasMany(s => s.Districts)
                .WithOne(d => d.State)
                .HasForeignKey(d => d.StateId);
        }

        public void SeedMockData()
        {
            if (!Countries.Any())
            {
                var countries = new List<Country>
                {
                    new Country { Name = "Country1", States = new List<State>
                    {
                        new State { Name = "State1", Districts = new List<District>
                        {
                            new District { Name = "State1District1", Population = 1000 },
                            new District { Name = "State1District2", Population = 1500 }
                        }},
                        new State { Name = "State2", Districts = new List<District>
                        {
                            new District { Name = "State2District1", Population = 2000 },
                            new District { Name = "State2District2", Population = 2500 }
                        }}
                    }},
                    new Country { Name = "Country2", States = new List<State>
                    {
                        new State { Name = "State3", Districts = new List<District>
                        {
                            new District { Name = "State3District1", Population = 3000 },
                            new District { Name = "State3District2", Population = 3500 }
                        }},
                        new State { Name = "State4", Districts = new List<District>
                        {
                            new District { Name = "State4District1", Population = 4000 },
                            new District { Name = "State4District2", Population = 4500 }
                        }}
                    }}
                };

                Countries.AddRange(countries);
                SaveChanges();
            }
        }
    }
}

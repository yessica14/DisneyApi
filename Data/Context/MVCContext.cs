using Alkemy.Disney.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Context
{
    public class MVCContext :DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Personage> Personage { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<Gender> Gender { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=DESKTOP-3K98E93;Database=DisneyDB;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}

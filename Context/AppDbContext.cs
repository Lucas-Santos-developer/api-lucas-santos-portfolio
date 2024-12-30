﻿using APILucasSantosPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace APILucasSantosPortfolio.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Service>? Services { get; set; }
    }
}

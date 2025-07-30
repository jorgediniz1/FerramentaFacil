﻿using FerramentaFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FerramentaFacil.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
          public DbSet<Categoria> Categorias {  get; set; }  
          public DbSet<Ferramenta> Ferramentas {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}

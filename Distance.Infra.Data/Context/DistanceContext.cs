using Distance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Distance.Infra.Data.Context
{
    public class DistanceContext : DbContext
    {
        public DbSet<CalculoHistoricoLog> CalculoHistoricoLog { get; set; }
        public DbSet<Distancia> Distancia { get; set; }
        public DistanceContext(DbContextOptions<DistanceContext> options) : base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Distancia>().HasKey(p => p.Id);
            modelBuilder.Entity<CalculoHistoricoLog>().HasKey(p => p.Id);

            #region Ignored Fields
            modelBuilder.Entity<Distancia>().Ignore(p => p.CalculoHistoricoLogs);
           

            #endregion Ignored Fields

            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder
               .UseLazyLoadingProxies();

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}

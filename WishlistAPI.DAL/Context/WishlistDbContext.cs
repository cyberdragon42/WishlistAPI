using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.DAL.Context
{
    public class WishlistDbContext: DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Category> Categories { get; set; }

        public WishlistDbContext(DbContextOptions<WishlistDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Currency>(x =>
            {
                x.Property(y => y.Id).HasDefaultValueSql("NEWID()");
                x.Property(c=>c.DollarCoefficient).HasColumnType("decimal(4, 2)");

            });

            modelBuilder.Entity<Category>(x =>
            {
                x.Property(y => y.Id).HasDefaultValueSql("NEWID()");
                x.Property(c => c.Name).HasMaxLength(500);
                x.Property(c => c.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<Item>(x =>
            {
                x.Property(y => y.Id).HasDefaultValueSql("NEWID()");
                x.Property(i => i.Name).HasMaxLength(500);
                x.Property(i => i.Description).HasMaxLength(1000);

                x.HasOne(i => i.Category)
                    .WithMany(c => c.Items)
                    .HasForeignKey(i => i.CategoryId);
                x.HasOne(i => i.Category)
                    .WithMany(c => c.Items)
                    .HasForeignKey(i => i.CategoryId);
                x.Property(i=>i.Price).HasColumnType("decimal(4, 2)");
            });
        }
    }
}

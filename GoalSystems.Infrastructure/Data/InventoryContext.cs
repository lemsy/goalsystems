using GoalSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GoalSystems.Infrastructure.Data
{
    /// <summary>
    /// Database context for items
    /// </summary>
    public class InventoryContext: DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(i => i.Name);
        }

        public DbSet<Item> Items { get; set; }
    }
}

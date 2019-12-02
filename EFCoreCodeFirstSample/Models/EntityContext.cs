using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreCodeFirstSample.Models
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Entity> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

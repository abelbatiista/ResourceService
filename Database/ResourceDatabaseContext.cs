using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Database
{
    public partial class ResourceDatabaseContext : DbContext
    {
        public ResourceDatabaseContext()
            : base("name=ResourceDatabaseContext")
        {
        }

        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceKind> ResourceKind { get; set; }
        public virtual DbSet<Suscriber> Suscriber { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceKind>()
                .HasMany(e => e.Resource)
                .WithRequired(e => e.ResourceKind)
                .WillCascadeOnDelete(false);
        }
    }
}

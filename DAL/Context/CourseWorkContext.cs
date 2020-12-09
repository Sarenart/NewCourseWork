using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class CourseWorkContext : DbContext
    {
        public CourseWorkContext()
            : base("name=CourseWorkContext")
        {
        }

        public virtual DbSet<Commodity> Commodity { get; set; }
        public virtual DbSet<CommodityTypeRef> CommodityTypeRef { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderSupplyStock> ProviderSupplyStock { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<SupplyLine> SupplyLine { get; set; }
        public virtual DbSet<SupplyStatusRef> SupplyStatusRef { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WarehouseLine> WarehouseLine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commodity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Commodity>()
                .HasMany(e => e.ProviderSupplyStock)
                .WithRequired(e => e.Commodity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commodity>()
                .HasMany(e => e.SupplyLine)
                .WithRequired(e => e.Commodity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commodity>()
                .HasMany(e => e.WarehouseLine)
                .WithRequired(e => e.Commodity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommodityTypeRef>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<CommodityTypeRef>()
                .HasMany(e => e.Commodity)
                .WithRequired(e => e.CommodityTypeRef)
                .HasForeignKey(e => e.CommodityType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.ProviderSupplyStock)
                .WithRequired(e => e.Provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Provider)
                .HasForeignKey(e => e.SupplierId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProviderSupplyStock>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Supply>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.SupplyLine)
                .WithRequired(e => e.Supply)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplyLine>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SupplyStatusRef>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<SupplyStatusRef>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.SupplyStatusRef)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.FirName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.FamName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.ApplicantId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Supply1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ArrangerId);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.WarehouseLine)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);
        }
    }
}

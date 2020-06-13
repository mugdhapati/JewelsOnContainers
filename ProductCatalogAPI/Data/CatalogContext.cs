using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogContext : DbContext                 //my classs inherit from DBContext(Database Context used by EntityFrameworkCore)
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CatalogType> CatalogTypes { get; set; }               //DbSet - is a db table //make a table with name CatalogTypes
        public DbSet<CatalogBrand> CatalogBrands { get; set; }              //make a table with name CatalogBrands
        public DbSet<CatalogItem> CatalogItems { get; set; }                 //make a table with name CatalogItems

        protected override void OnModelCreating(ModelBuilder modelBuilder)          //Officially as a child you are override'ng your parents on modalcreating method  i.e., DbContext
        {
            modelBuilder.Entity<CatalogBrand>(e =>                                                                     //provide your instructions on how to build the tables    & ModelBuilder is the one to do this
            {
                e.ToTable("CatalogBrands");
                e.Property(b => b.Id).IsRequired()
                                     .UseHiLo("catalog_brand_hilo");                          //UseHiLo is used to provide a auto generated number
                e.Property(b => b.Brand)
                            .IsRequired()
                            .HasMaxLength(100);

            });
            modelBuilder.Entity<CatalogType>(e =>
            {
                e.ToTable("CatalogTypes");
                e.Property(t => t.Id).IsRequired()
                                    .UseHiLo("catalog_type_id");
                e.Property(t => t.Type).IsRequired()
                                        .HasMaxLength(100);
            });
            modelBuilder.Entity<CatalogItem>(e =>
            {
                e.ToTable("Catalog");
                e.Property(c => c.Id).IsRequired()
                                     .UseHiLo("catalog_hilo");
                e.Property(c => c.Name).IsRequired()
                                        .HasMaxLength(200);
                e.Property(c => c.Price).IsRequired();

                e.HasOne(c => c.CatalogType)
                    .WithMany()
                        .HasForeignKey(c => c.CatalogTypeId);
                e.HasOne(c => c.CatalogBrand)
                    .WithMany()
                        .HasForeignKey(c => c.CatalogBrandId);

            });
        }
    }
}

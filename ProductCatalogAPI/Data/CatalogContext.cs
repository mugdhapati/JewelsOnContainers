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
        public DbSet<CatalogType> CatalogTypes { get; set; }               //DbSet - is a db table //make a table with name CatalogTypes
        public DbSet<CatalogBrand> CatalogBrands { get; set; }              //make a table with name CatalogBrands
        public DbSet<CatalogItem> CatalogItems { get; set; }                 //make a table with name CatalogItems

        protected override void OnModelCreating(ModelBuilder modelBuilder)          //Officially as a child you are override'ng your parents on modalcreating method  i.e., DbContext
        {                   
                                                                                   //provide your instructions on how to build the tables & ModelBuilder is the one to do this
        }
    }
}

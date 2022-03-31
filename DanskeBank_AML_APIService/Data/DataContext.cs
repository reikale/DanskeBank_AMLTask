
using DanskeBank_AML_APIService.Controllers;
using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService;
using DanskeBank_AMLTask_APIService.Models;
using Microsoft.EntityFrameworkCore;


namespace DanskeBank_AML_APIService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
            this.Database.EnsureCreated();
        }

        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Taxes> Taxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxRules>().HasData(new TaxRules { Id = 1, Name = "AddTaxes" });
            modelBuilder.Entity<TaxRules>().HasData(new TaxRules { Id = 2, Name = "ChooseSmallest" });
            modelBuilder.Entity<TaxType>().HasData(new TaxType { Id = 1, Name = "Yearly" });
            modelBuilder.Entity<TaxType>().HasData(new TaxType { Id = 2, Name = "Monthly" });
            modelBuilder.Entity<TaxType>().HasData(new TaxType { Id = 3, Name = "Weekly" });
            modelBuilder.Entity<TaxType>().HasData(new TaxType { Id = 4, Name = "Daily" });

        }
    }
}

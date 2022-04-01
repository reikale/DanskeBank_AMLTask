using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Models;
using Microsoft.EntityFrameworkCore;

namespace DanskeBank_AML_APIService.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Taxes> Taxes { get; set; }
        public DbSet<TaxRules> TaxRules { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
    }
}

using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Models;

namespace DanskeBank_AML_APIService.Interfaces
{
    public interface ITaxesController
    {
        public List<Taxes> ReturnAllMunicipalityTaxes(string name);
        public TaxRules ReturnTaxRule(string name);
        public List<Taxes> ReturnTaxesByDate(List<Taxes> listOfTaxes, string stringDate);
        public DateTime StringToDateTimeConverter(string stringDate);
        public bool CheckIfMunicipalityExists(string municipality);
    }
}

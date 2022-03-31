using DanskeBank_AML_APIService.Data;
using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Models;

namespace DanskeBank_AML_APIService
{
    public class TaxesController
    {
        private DataContext _dataContext;
        public TaxesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Taxes> ReturnAllMunicipalityTaxes(string name)
        {
            return _dataContext.Taxes.Where(x => x.Municipality == name).ToList();
        }
        public TaxRules ReturnTaxRule(string name)
        {
            return _dataContext.Municipalities.Where(x => x.Name == name).Select(x => x.Rule).SingleOrDefault();
        }
        public List<Taxes> ReturnTaxesByDate(List<Taxes> listOfTaxes, string stringDate)
        {
            DateTime inputDate = StringToDateTimeConverter(stringDate);
            List<Taxes> output = listOfTaxes.Where(x=> x.StartDate <= inputDate && x.EndDate >= inputDate ).ToList();
            return output;
        }
        public DateTime StringToDateTimeConverter(string stringDate)
        {
            while (true)
            {
                DateTime newDate;
                if (DateTime.TryParse(stringDate, out newDate))
                {
                    return newDate;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The input is invalid. Please try again");
                }
            }
        }
    }
}

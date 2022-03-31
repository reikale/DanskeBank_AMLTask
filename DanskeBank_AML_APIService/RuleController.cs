using DanskeBank_AML_APIService.Data;
using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Models;

namespace DanskeBank_AML_APIService
{
    public class RuleController
    {
        private Calculator _calculator;
        private double _totalTaxRate;
        private DataContext _dataContext;
        public RuleController(Calculator calculator, DataContext datacontext)
        {
            _calculator = calculator;
            _dataContext = datacontext;
        }
        // RULES ACTIONS DELEGATE
        public Action[] CalculationByRule(List<Taxes> globalListOfTaxes) => new Action[]
        {
            () => AddTaxesAction(globalListOfTaxes),
            () => ChooceSmallestAction(globalListOfTaxes),
        };

        // RULES AND THEIR IMPLEMENTATION
        public void AddTaxesAction(List<Taxes> globalListOfTaxes)
        {
            double output = 0;
            foreach (Taxes taxes in globalListOfTaxes)
            {
                output += taxes.TaxRate;
            }
            _totalTaxRate = output;
            
        }
        public void ChooceSmallestAction(List<Taxes> globalListOfTaxes)
        {
            _totalTaxRate = globalListOfTaxes.Select(x => x.TaxRate).Min();
        }

        // OTHER METHODS THAT BELONGS TO RULES
        public double ReturnTotalTaxRate()
        {
            return _totalTaxRate;
        }
        public void ChangeRuleToMunicipality(string municipality, int number)
        {
            Municipality municipalityObject = _dataContext.Municipalities.Where(x => x.Name == municipality).SingleOrDefault();
            TaxRules newRule = _dataContext.TaxRules.Where(x => x.Id == number).SingleOrDefault();
            municipalityObject.Rule = newRule;
        }

    }
}

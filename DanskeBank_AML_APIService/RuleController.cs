using DanskeBank_AML_APIService.Data;
using DanskeBank_AML_APIService.Interfaces;
using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Models;

namespace DanskeBank_AML_APIService
{
    public class RuleController: IRuleController
    {
        private ICalculator _calculator;
        private double _totalTaxRate;
        private IDataContext _dataContext;
        public RuleController(ICalculator calculator, IDataContext datacontext)
        {
            _calculator = calculator;
            _dataContext = datacontext;
        }

        // EACH RULE CALCULATION DELEGATE
        public Action[] CalculationByRule(List<Taxes> globalListOfTaxes) => new Action[]
        {
            () => AddTaxesAction(globalListOfTaxes),
            () => ChooceSmallestAction(globalListOfTaxes),
            // -- ADDITIONAL TAX RULES COULD BE ADDED HERE --
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
            if(globalListOfTaxes != null)
            {
                _totalTaxRate = globalListOfTaxes.Select(x => x.TaxRate).Min();
            }
            
        }
        // -- ADDITIONAL TAX RULES COULD BE ADDED HERE --


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

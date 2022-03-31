using DanskeBank_AMLTask_APIService.Models;

namespace DanskeBank_AML_APIService
{
    public class RuleController
    {
        private Calculator _calculator;
        private double _totalTaxRate;
        public RuleController(Calculator calculator)
        {
            _calculator = calculator;
        }
        public Action[] CalculationByRule(List<Taxes> globalListOfTaxes) => new Action[]
        {
            () => AddTaxesAction(globalListOfTaxes),
            () => ChooceSmallestAction(globalListOfTaxes),
        };

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
        public double ReturnTotalTaxRate()
        {
            return _totalTaxRate;
        }
    }
}

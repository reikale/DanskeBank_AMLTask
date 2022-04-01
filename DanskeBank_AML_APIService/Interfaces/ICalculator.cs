using DanskeBank_AMLTask_APIService.Models;

namespace DanskeBank_AML_APIService.Interfaces
{
    public interface ICalculator
    {
        public double TaxCalculation(string name, string date);
        public void CalculateTax(List<Taxes> listOfTaxes, string stringDate, int rule);
        public void TaskDelegation(Action[] actions, int selection);
        public double ReturnTotalTaxRate(double input);

    }
}

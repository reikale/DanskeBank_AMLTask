using DanskeBank_AMLTask_APIService.Models;

namespace DanskeBank_AML_APIService.Interfaces
{
    public interface IRuleController
    {
        public void AddTaxesAction(List<Taxes> globalListOfTaxes);
        public void ChooceSmallestAction(List<Taxes> globalListOfTaxes);
        public double ReturnTotalTaxRate();
        public void ChangeRuleToMunicipality(string municipality, int number);
    }
}

using DanskeBank_AML_APIService.Data;
using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Models;
using System.Collections.Generic;

namespace DanskeBank_AML_APIService
{
    public class Calculator
    {
        private DataContext _dataContext;
        private TaxesController _taxesController;
        private RuleController _ruleController;

        List<Taxes> globalListOfTaxes = new List<Taxes>();
        public Calculator(DataContext datacontext, TaxesController taxesController, RuleController ruleController)
        {
            _dataContext = datacontext;
            _taxesController = new TaxesController(_dataContext);
            _ruleController = new RuleController(this, _dataContext);
        }

        public double TaxCalculation(string name, string date)
        {
            List<Taxes> listOfTaxes = _taxesController.ReturnAllMunicipalityTaxes(name);
            TaxRules TaxRule = _taxesController.ReturnTaxRule(name);
            CalculateTax(listOfTaxes, date, TaxRule.Id);
            return _ruleController.ReturnTotalTaxRate();
        }
        public void CalculateTax(List<Taxes> listOfTaxes, string stringDate, int rule)
        {
            globalListOfTaxes = _taxesController.ReturnTaxesByDate(listOfTaxes, stringDate);
            TaskDelegation(_ruleController.CalculationByRule(globalListOfTaxes), rule);
        }

        public void TaskDelegation(Action[] actions, int selection)
        {
            actions[selection-1]();
        }
        public double ReturnTotalTaxRate(double input)
        {
            return input;
        }
    }
}

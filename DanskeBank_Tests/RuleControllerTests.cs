using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanskeBank_AML_APIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanskeBank_AMLTask_APIService.Models;
using Moq;
using DanskeBank_AML_APIService.Interfaces;

namespace DanskeBank_AML_APIService.Tests
{
    
    [TestClass()]
    public class RuleControllerTests
    {
        private Mock<IDataContext> _dataContext;
        private Mock<IRuleController> _mockRuleController;
        private Mock<IRuleController> _ruleController;
        private ICalculator _calculator;


        [TestInitialize]
        public void Setup()
        {
            _dataContext = new Mock<IDataContext>();
            _mockRuleController = new Mock<IRuleController>();
            _ruleController = new Mock<IRuleController>();

        }

        [DataRow(3, 0.2, 1.2)]
        [DataRow(10, 0.1, 5.5)]
        [DataTestMethod()]
        public void ReturnTotalTaxRateTest(int count, double taxRate, double expected)
        {
            List<Taxes> allMockTaxes = new List<Taxes>();
            double sum = 0;
            double newTaxRate = 0;
            // the assignements of the tax rates:
            for (int i = 0; i < count; i++)
            {
                newTaxRate += taxRate + (i / 10);
                Taxes newTax = new Taxes();
                newTax.TaxRate = newTaxRate;
                double oldTaxRate = newTaxRate;
                allMockTaxes.Add(newTax);

            };
            foreach (var item in allMockTaxes)
            {
                sum += item.TaxRate;
            }
            _ruleController.Setup(x => x.AddTaxesAction(allMockTaxes));
            _ruleController.Setup(x => x.ReturnTotalTaxRate()).Returns(sum);

            
            double actual = Math.Round(_ruleController.Object.ReturnTotalTaxRate(), 2);


            Assert.AreEqual(expected, actual);
        }
        
    }
}
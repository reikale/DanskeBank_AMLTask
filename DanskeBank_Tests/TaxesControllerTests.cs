using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanskeBank_AML_APIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanskeBank_AML_APIService.Data;
using DanskeBank_AML_APIService.Interfaces;
using Moq;
using DanskeBank_AMLTask_APIService.Models;
using DanskeBank_AML_APIService.Models;

namespace DanskeBank_AML_APIService.Tests
{
    [TestClass()]
    public class TaxesControllerTests
    {
        private Mock<IDataContext> _database;
        private Mock<ITaxesController> _taxesController;



        [TestInitialize]
        public void Setup()
        {
            _database = new Mock<IDataContext>();
            _taxesController = new Mock<ITaxesController>();

        }

        [DataRow("Test", 3, "Test0")]
        [DataRow("AnotherOne", 100, "AnotherOne0")]
        [DataTestMethod()]
        public void ReturnAllMunicipalityTaxesTest(string inputMunicipality, int count, string expected)
        {
            // Arrange
            List<Taxes> allMockTaxes = new List<Taxes>();
            for (int i = 0; i < count; i++)
            {
                Taxes newTax = new Taxes();
                newTax.Municipality = inputMunicipality+i;
                allMockTaxes.Add(newTax);
            };

            _taxesController.Setup(x => x.ReturnAllMunicipalityTaxes(inputMunicipality)).Returns(allMockTaxes);

            // Act
            List<Taxes> actual = _taxesController.Object.ReturnAllMunicipalityTaxes(inputMunicipality);
            int actualCount = actual.Count();
            var actualMunicipality = actual[0].Municipality;
            // Assert
            Assert.AreEqual(count, actualCount);
            Assert.AreEqual(expected, actualMunicipality);
        }

        [DataRow("2020-01-01")]
        [DataRow("0001-01-01")]
        [DataTestMethod()]
        public void StringToDateTimeConverterTest(string inputDate)
        {
            // Arrange
            DateTime parsedDate = DateTime.Parse(inputDate);
            _taxesController.Setup(x => x.StringToDateTimeConverter(inputDate)).Returns(parsedDate);

            //Act
            DateTime expected = DateTime.Parse(inputDate);
            DateTime actual = _taxesController.Object.StringToDateTimeConverter(inputDate);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        
        
    }
}
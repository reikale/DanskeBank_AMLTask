using DanskeBank_AML_APIService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanskeBank_AML_APIService.Controllers
{

   
    [ApiController]
    [Route("api/")]
    public class APIController : ControllerBase
    {
        private readonly ILogger<APIController> _logger;
        private DataContext _dataContext;
        private Calculator _calculator;
        private TaxesController _taxesController;
        private RuleController _ruleController;

        public APIController(ILogger<APIController> logger, DataContext datacontext)
        {
            _logger = logger;
            _dataContext = datacontext;
            _taxesController = new TaxesController(_dataContext);
            _calculator = new Calculator(_dataContext, _taxesController, _ruleController);
            _ruleController = new RuleController(_calculator);
        }

        [HttpGet]
        [Route("{text}")]
        public string GetString(string text)
        {
            return text;
        }
        [HttpGet]
        [Route("values/{municipality}/{date}")]
        public double GetCalculatedTax(string municipality, string date)
        {
            double output = _calculator.TaxCalculation(municipality, date);
            int municipalityRule = _taxesController.ReturnTaxRule(municipality).Id;
            _logger.LogInformation($"Result: {date} - {municipality} - {municipalityRule} - {output}");
            // log something
            return output;
        }
        [HttpPost]
        [Route("values/{municipality}/{date}")]
        public void InsertValues(string municipality, string date)
        {

        }
    }
}

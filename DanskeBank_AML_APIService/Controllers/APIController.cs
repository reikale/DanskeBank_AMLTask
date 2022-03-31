using DanskeBank_AML_APIService.Data;
using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Models;
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
            _ruleController = new RuleController(_calculator, _dataContext);
        }

        [HttpGet]
        [Route("get/{municipality}/{date}")]
        public ActionResult GetCalculatedTax(string municipality, string date)
        {
            if (!_taxesController.CheckIfMunicipalityExists(municipality) || municipality == null)
            {
                _logger.LogError($"There is no such municipality in database : {municipality}", municipality);
                return BadRequest($"There is no such municipality in database : {municipality}");
            }
            double output = _calculator.TaxCalculation(municipality, date);
            output = Math.Round(output, 2);
            int municipalityRule = _taxesController.ReturnTaxRule(municipality).Id;
            _logger.LogInformation($"Municipality: {municipality} - Date: {date} - Tax Rule: {municipalityRule} - Result: {output}");

            return Ok(output);
        }

        [HttpPut]
        [Route("edit/{municipality}/{rule}")]
        public ActionResult InsertValues(string municipality, string rule)
        {
            if (!_taxesController.CheckIfMunicipalityExists(municipality) || municipality == null)
            {
                _logger.LogError($"There is no such municipality in database : {municipality}", municipality);
                return BadRequest($"There is no such municipality in database : {municipality}");
            }
            int number;

            bool success = int.TryParse(rule, out number);
            if (!success)
            {
                _logger.LogError($"That's not a number : {rule}", rule);
                return BadRequest($"That's not a number : {rule}");
            }
            if (!_dataContext.TaxRules.Select(x => x.Id).ToList().Contains(number))
            {
                _logger.LogError($"There is no such rule in database : {number}");
                return BadRequest($"There is no such rule in database : {number}");
            }

            _ruleController.ChangeRuleToMunicipality(municipality, number);
            _logger.LogInformation($"{municipality} municipality rule was changed to {number}");
            _dataContext.SaveChanges();

            return Ok(_dataContext.Municipalities.Where(x => x.Name == municipality).SingleOrDefault());
        }
    }
}

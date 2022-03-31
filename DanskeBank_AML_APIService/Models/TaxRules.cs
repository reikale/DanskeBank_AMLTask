using System.ComponentModel.DataAnnotations;

namespace DanskeBank_AML_APIService.Models
{
    public class TaxRules
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }

}

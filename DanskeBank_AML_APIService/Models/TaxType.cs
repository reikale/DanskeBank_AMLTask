using System.ComponentModel.DataAnnotations;

namespace DanskeBank_AML_APIService.Models
{
    public class TaxType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

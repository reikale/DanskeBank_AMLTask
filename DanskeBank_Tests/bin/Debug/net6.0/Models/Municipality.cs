using DanskeBank_AML_APIService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank_AMLTask_APIService.Models
{
    public class Municipality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TaxRules Rule { get; set; }
       
    }
}

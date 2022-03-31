using DanskeBank_AML_APIService.Models;
using DanskeBank_AMLTask_APIService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank_AMLTask_APIService.Models
{
    public class Taxes : ITax
    {
        public int Id { get; set; }
        public string Municipality { get; set; }
        public TaxType TaxType { get; set; }
        public double TaxRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

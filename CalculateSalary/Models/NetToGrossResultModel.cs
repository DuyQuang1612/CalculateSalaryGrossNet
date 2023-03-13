using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculateSalary.Models
{
    public class NetToGrossResultModel
    {
        public decimal GrossSalary { get; set; }
        public decimal Insurance { get; set; }
        public decimal Tax { get; set; }
        public decimal NetSalary { get; set; }
    }
}
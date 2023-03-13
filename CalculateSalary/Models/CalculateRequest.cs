using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculateSalary.Models
{
    public class CalculateRequest
    {
        public short PolicyApply { get; set; }
        public decimal Salary { get; set; }
        public bool CalculateOnSalary { get; set; }
        public decimal SalaryInsurance { get; set; }
        public int Area { get; set; }
        public int PersonDependent { get; set; }
    }
}
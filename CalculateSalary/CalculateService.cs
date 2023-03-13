using CalculateSalary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculateSalary
{
    public class CalculateService
    {
        public NetToGrossResultModel CalculateGrossToNet(CalculateRequest model)
        {
            var result = new NetToGrossResultModel();
            //Lấy mức lương đóng bảo hiểm 
            //Nếu đóng trên lương chính thức thì lấy = lương chính thức 
            model.SalaryInsurance = model.CalculateOnSalary ? model.Salary : model.SalaryInsurance;

            //Tính bảo hiểm xã hội (8% lương bảo hiểm)
            decimal socialInsurance = model.SalaryInsurance * (decimal)0.08;

            //Tính bảo hiểm y tế (1,5 % lương bảo hiểm)
            decimal medicalInsurance = model.SalaryInsurance * (decimal)0.015;

            //Tính bảo hiểm thất nghiệp (1% lương bảo hiểm)
            decimal unemploymentInsurance = model.SalaryInsurance * (decimal)0.01;

            //Tính thu nhập trước thuế 
            decimal insurance = (socialInsurance + medicalInsurance + unemploymentInsurance);
            decimal incomeBeforeTax = model.Salary - insurance;

            //tính giảm trừ gia cảnh bản thân
            decimal personalAllowances = 11000000;

            //tính giảm trừ người thân
            decimal familyAllowances = model.PersonDependent * 4400000;

            //Tính thu nhập chịu thuế
            decimal incomeTax = incomeBeforeTax - personalAllowances - familyAllowances;


            //Tính thuế thu nhập cá nhân 
            decimal personalIncomeTax = CalculatePersonalIncomeTax(incomeTax);

            //Tinh lương NET

            decimal netSalary = incomeBeforeTax - personalIncomeTax;


            //Gán lại giá trị để trả ra
            result.GrossSalary = model.Salary;
            result.NetSalary = netSalary;
            result.Insurance = insurance;
            result.Tax = personalIncomeTax;
            return result;
        }

        //public NetToGrossResultModel CalculateNetToGross(CalculateRequest model)
        //{
        //    var result = new NetToGrossResultModel();
        //    //Lấy mức lương đóng bảo hiểm 
        //    //Nếu đóng trên lương chính thức thì lấy = lương chính thức 
        //    model.SalaryInsurance = model.CalculateOnSalary ? model.Salary : model.SalaryInsurance;

        //    //Tính bảo hiểm xã hội (8% lương bảo hiểm)
        //    decimal socialInsurance = model.SalaryInsurance * (decimal)0.08;

        //    //Tính bảo hiểm y tế (1,5 % lương bảo hiểm)
        //    decimal medicalInsurance = model.SalaryInsurance * (decimal)0.015;

        //    //Tính bảo hiểm thất nghiệp (1% lương bảo hiểm)
        //    decimal unemploymentInsurance = model.SalaryInsurance * (decimal)0.01;

        //    //Tính thu nhập trước thuế 
        //    decimal insurance = (socialInsurance + medicalInsurance + unemploymentInsurance);
        //    decimal incomeBeforeTax = model.Salary - insurance;

        //    //tính giảm trừ gia cảnh bản thân
        //    decimal personalAllowances = 11000000;

        //    //tính giảm trừ người thân
        //    decimal familyAllowances = model.PersonDependent * 4400000;

        //    //Tính thu nhập chịu thuế
        //    decimal incomeTax = incomeBeforeTax - personalAllowances - familyAllowances;


        //    //Tính thuế thu nhập cá nhân 
        //    decimal personalIncomeTax = CalculatePersonalIncomeTax(incomeTax);

        //    //Tinh lương NET

        //    decimal netSalary = incomeBeforeTax - personalIncomeTax;


        //    //Gán lại giá trị để trả ra
        //    result.GrossSalary = model.Salary;
        //    result.NetSalary = netSalary;
        //    result.Insurance = insurance;
        //    result.Tax = personalIncomeTax;
        //    return result;
        //}

        private decimal CalculatePersonalIncomeTax(decimal incomeTax)
        {
            decimal personalIncomeTax = 0;
            if(incomeTax <= 5000000)
            {
                personalIncomeTax = incomeTax * (decimal)0.05;
            }
            else if (5000000 < incomeTax && incomeTax <= 10000000)
            {
                personalIncomeTax = incomeTax * (decimal)0.1 - 250000;
            }
            else if (10000000 < incomeTax && incomeTax <= 18000000)
            {
                personalIncomeTax = incomeTax * (decimal)0.15 - 750000;
            }
            else if (18000000 < incomeTax && incomeTax <= 32000000)
            {
                personalIncomeTax = incomeTax * (decimal)0.2 - 1650000;
            }
            else if (32000000 < incomeTax && incomeTax <= 52000000)
            {
                personalIncomeTax = incomeTax * (decimal)0.22 - 3250000;
            }
            else if (52000000 < incomeTax && incomeTax <= 80000000)
            {
                personalIncomeTax = incomeTax * (decimal)0.3 - 5850000;
            }
            else if(incomeTax > 80000000)
            {
                personalIncomeTax = incomeTax * (decimal)0.35 - 9850000;
            }

            return personalIncomeTax;
        }
    }
}
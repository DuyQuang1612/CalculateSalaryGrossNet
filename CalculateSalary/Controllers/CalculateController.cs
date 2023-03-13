using CalculateSalary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculateSalary.Controllers
{
    public class CalculateController : Controller
    {
        private CalculateService _calculateService;
        public CalculateController()
        {
            _calculateService = new CalculateService();
        }

        public ActionResult GrossToNet(CalculateRequest model)
        {
            var result = _calculateService.CalculateGrossToNet(model);
            return Json(result);
        }


    }
}
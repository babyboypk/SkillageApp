using SkillageApp.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillageApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IVWDailyPricesService _vwDailyPricesService;
        public HomeController(IVWDailyPricesService vwDailyPricesService)
        {
            _vwDailyPricesService = vwDailyPricesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDailyPrices(FormCollection frmCollection)
        {
            //Get Page Size Form Request
            var pageSize = Convert.ToInt32(frmCollection["pageSize"]);

            //Get Page Index From Request
            var page = Convert.ToInt32(frmCollection["page"]);

            //Call Service Get Data
            var data = _vwDailyPricesService.GetAllPaging("", page, pageSize);

            return Json(data);
        }
    }
}
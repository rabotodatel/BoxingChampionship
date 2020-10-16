using BoxingChampionshipWebApplication.Models;
using BoxingChampionshipWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxingChampionshipWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private CrudService _service;

        public HomeController()
        {
            _service = new CrudService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            return Json(new { rows = _service.GetRankings() }, JsonRequestBehavior.AllowGet);
        }
    }
}
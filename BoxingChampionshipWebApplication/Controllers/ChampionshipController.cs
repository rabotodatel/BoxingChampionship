using BoxingChampionshipWebApplication.Models;
using BoxingChampionshipWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxingChampionshipWebApplication.Controllers
{
    public class ChampionshipController : Controller
    {
        private CrudService _service;
        public ChampionshipController()
        {
            _service = new CrudService();
        }

        // GET: Championship
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (BattleContext db = new BattleContext())
            {
                var battles = db.Battles.ToList<Battle>();
                var jsonData = Json(new { rows = battles }, JsonRequestBehavior.AllowGet);
                return jsonData;
            }
        }

        public string InsertBattle([Bind(Exclude ="Id")]Battle battle)
        {
            string msg;
            if (ModelState.IsValid)
            {
                try
                {
                    _service.InsertBattle(battle);
                    msg = "Battle inserted";
                }
                catch (Exception e)
                {
                    msg = e.Message;
                }
            }
            else
            {
                msg = "Error";
            }
            return msg;
        }

        public string UpdateBattle(int id, Battle battle)
        {
            string msg;
            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateBattle(id, battle);
                    msg = "Battle updated";
                }
                catch (Exception e)
                {
                    msg = e.Message;
                }
            }
            else
            {
                msg = "Error";
            }
            return msg;
        }

        public string DeleteBattle(int id)
        {
            string msg;
            try
            {
                _service.DeleteBattle(id);
                msg = "Battle deleted";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
    }
}
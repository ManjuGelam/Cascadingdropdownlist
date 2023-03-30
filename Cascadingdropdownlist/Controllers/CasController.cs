using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cascadingdropdownlist.Models;

namespace Cascadingdropdownlist.Controllers
{
    public class CasController : Controller
    {
        // GET: Cas
        public ActionResult Index()
        {
            CascadingDBEntities1 cd = new CascadingDBEntities1();
            ViewBag.CountryList = new SelectList(GetCountryList(), "cid", "cname");
            return View();
        }
        public List<country>GetCountryList()
        {
            CascadingDBEntities1 cd = new CascadingDBEntities1();
            List<country>countries = cd.countries.ToList();
            return countries;
        }
        public ActionResult GetStateList(int cid)
        {
            CascadingDBEntities1 cd = new CascadingDBEntities1();
            List<state> selectList = cd.states.Where(x => x.cid == cid).ToList();
            ViewBag.Slist = new SelectList(selectList, "sid", "sname");
            return PartialView("DisplayStates");
        }
        public ActionResult GetCityList(int sid)
        {
            CascadingDBEntities1 cd = new CascadingDBEntities1();
            List<city> selectList = cd.cities.Where(x => x.sid == sid).ToList();
            ViewBag.Citylist = new SelectList(selectList, "cityid", "cityname");
            return PartialView("DisplayCities");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tenders.Models;
using PagedList.Mvc;
using PagedList;


namespace Tenders.Controllers
{
    public class HomeController : Controller
    {
        private TenderContext db = new TenderContext();


        public ActionResult Index(int? page)
        {
            var tenders = db.tenders.Include(t => t.Category).Include(t => t.CurrencyBudget).Include(t => t.OrgTender).Include(t => t.ViewTender);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(tenders.OrderBy(p => p.TenderID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }


     



        public ActionResult About()
        {
            ViewBag.Message = "My application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";

            return View();
        }
    }
}
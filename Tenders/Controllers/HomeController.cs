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

namespace Tenders.Controllers
{
    public class HomeController : Controller
    {
        private TenderContext db = new TenderContext();
        public async Task<ActionResult> Index()
        {
            var tenders = db.tenders.Include(t => t.Category).Include(t => t.CurrencyBudget).Include(t => t.OrgTender).Include(t => t.ViewTender);
            return View(await tenders.ToListAsync());
        
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
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
        public int pageSize = 4;

        public ActionResult Index(int page = 1)
        {

             var Tenders = db.tenders.Include(t => t.Category).Include(t => t.CurrencyBudget).Include(t => t.OrgTender).Include(t => t.ViewTender);


            TenderListViewModel model = new TenderListViewModel
            {

                Tenders = Tenders.OrderBy(p => p.TenderID).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = pageSize,
                    TotalItems = Tenders.Count()
                }

            };


            return View(model);
      
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
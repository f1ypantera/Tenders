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


        public  ActionResult Index(int? page,string searchString,string searchDesription,string organizator)
        {

            
            int pageSize = 3;
            int pageNumber = (page ?? 1);


            var tenders =  db.tenders.Include(t => t.Category).Include(t => t.CurrencyBudget).Include(t => t.OrgTender).Include(t => t.ViewTender).OrderBy(p => p.TenderID).ToPagedList(pageNumber, pageSize);


            if (!string.IsNullOrEmpty(searchString))
            {
                tenders = tenders.Where(s => s.SubjectTender.Contains(searchString)).ToPagedList(pageNumber, pageSize);
            }
            if (!string.IsNullOrEmpty(searchDesription))
            {
                tenders = tenders.Where(s => s.DescriptionTender.Contains(searchString)).ToPagedList(pageNumber, pageSize);
            }


            return View(tenders);
        }
        public async Task<ActionResult> DetailDesription(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Tender tender = await db.tenders.Include(t => t.Category).Include(t => t.CurrencyBudget).Include(t => t.OrgTender).Include(t => t.ViewTender).SingleOrDefaultAsync(x=>x.TenderID == id);
          


            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
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
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
    public class OrgTendersController : Controller
    {
        private TenderContext db = new TenderContext();

   
        public async Task<ActionResult> Index()
        {
            return View(await db.orgTenders.ToListAsync());
        }

        
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgTender orgTender = await db.orgTenders.FindAsync(id);
            if (orgTender == null)
            {
                return HttpNotFound();
            }
            return View(orgTender);
        }

   
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrgTenderID,ListOrgTender")] OrgTender orgTender)
        {
            if (ModelState.IsValid)
            {
                db.orgTenders.Add(orgTender);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(orgTender);
        }

 
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgTender orgTender = await db.orgTenders.FindAsync(id);
            if (orgTender == null)
            {
                return HttpNotFound();
            }
            return View(orgTender);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrgTenderID,ListOrgTender")] OrgTender orgTender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orgTender).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(orgTender);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgTender orgTender = await db.orgTenders.FindAsync(id);
            if (orgTender == null)
            {
                return HttpNotFound();
            }
            return View(orgTender);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrgTender orgTender = await db.orgTenders.FindAsync(id);
            db.orgTenders.Remove(orgTender);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

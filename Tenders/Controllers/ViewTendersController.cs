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
    public class ViewTendersController : Controller
    {
        private TenderContext db = new TenderContext();

        // GET: ViewTenders
        public async Task<ActionResult> Index()
        {
            return View(await db.viewTenders.ToListAsync());
        }

        // GET: ViewTenders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewTender viewTender = await db.viewTenders.FindAsync(id);
            if (viewTender == null)
            {
                return HttpNotFound();
            }
            return View(viewTender);
        }

        // GET: ViewTenders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewTenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ViewTenderID,ListViewTenders")] ViewTender viewTender)
        {
            if (ModelState.IsValid)
            {
                db.viewTenders.Add(viewTender);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(viewTender);
        }

        // GET: ViewTenders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewTender viewTender = await db.viewTenders.FindAsync(id);
            if (viewTender == null)
            {
                return HttpNotFound();
            }
            return View(viewTender);
        }

        // POST: ViewTenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ViewTenderID,ListViewTenders")] ViewTender viewTender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewTender).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewTender);
        }

        // GET: ViewTenders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewTender viewTender = await db.viewTenders.FindAsync(id);
            if (viewTender == null)
            {
                return HttpNotFound();
            }
            return View(viewTender);
        }

        // POST: ViewTenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewTender viewTender = await db.viewTenders.FindAsync(id);
            db.viewTenders.Remove(viewTender);
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

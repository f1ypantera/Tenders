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
    public class TendersController : Controller
    {
        private TenderContext db = new TenderContext();

        // GET: Tenders
        public async Task<ActionResult> Index()
        {
            var tenders = db.tenders.Include(t => t.Category).Include(t => t.CurrencyBudget).Include(t => t.OrgTender).Include(t => t.ViewTender);
            return View(await tenders.ToListAsync());
        }

        // GET: Tenders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = await db.tenders.FindAsync(id);

         
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // GET: Tenders/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.categories, "CategoryID", "ListCategory");
            ViewBag.CurrencyBudgetID = new SelectList(db.currencyBudgets, "CurrencyBudgetID", "ListCurrencyBudget");
            ViewBag.OrgTenderID = new SelectList(db.orgTenders, "OrgTenderID", "ListOrgTender");
            ViewBag.ViewTenderID = new SelectList(db.viewTenders, "ViewTenderID", "ListViewTenders");
            return View();
        }

        // POST: Tenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TenderID,SubjectTender,DescriptionTender,OrgTenderID,ViewTenderID,CategoryID,Budget,CurrencyBudgetID,SponsorShip")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.tenders.Add(tender);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.categories, "CategoryID", "ListCategory", tender.CategoryID);
            ViewBag.CurrencyBudgetID = new SelectList(db.currencyBudgets, "CurrencyBudgetID", "ListCurrencyBudget", tender.CurrencyBudgetID);
            ViewBag.OrgTenderID = new SelectList(db.orgTenders, "OrgTenderID", "ListOrgTender", tender.OrgTenderID);
            ViewBag.ViewTenderID = new SelectList(db.viewTenders, "ViewTenderID", "ListViewTenders", tender.ViewTenderID);
            return View(tender);
        }

        // GET: Tenders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = await db.tenders.FindAsync(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.categories, "CategoryID", "ListCategory", tender.CategoryID);
            ViewBag.CurrencyBudgetID = new SelectList(db.currencyBudgets, "CurrencyBudgetID", "ListCurrencyBudget", tender.CurrencyBudgetID);
            ViewBag.OrgTenderID = new SelectList(db.orgTenders, "OrgTenderID", "ListOrgTender", tender.OrgTenderID);
            ViewBag.ViewTenderID = new SelectList(db.viewTenders, "ViewTenderID", "ListViewTenders", tender.ViewTenderID);
            return View(tender);
        }

        // POST: Tenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TenderID,SubjectTender,DescriptionTender,OrgTenderID,ViewTenderID,CategoryID,Budget,CurrencyBudgetID,date,SponsorShip")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tender).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.categories, "CategoryID", "ListCategory", tender.CategoryID);
            ViewBag.CurrencyBudgetID = new SelectList(db.currencyBudgets, "CurrencyBudgetID", "ListCurrencyBudget", tender.CurrencyBudgetID);
            ViewBag.OrgTenderID = new SelectList(db.orgTenders, "OrgTenderID", "ListOrgTender", tender.OrgTenderID);
            ViewBag.ViewTenderID = new SelectList(db.viewTenders, "ViewTenderID", "ListViewTenders", tender.ViewTenderID);
            return View(tender);
        }

        // GET: Tenders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = await db.tenders.FindAsync(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // POST: Tenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tender tender = await db.tenders.FindAsync(id);
            db.tenders.Remove(tender);
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

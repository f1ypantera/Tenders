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
    public class CurrencyBudgetsController : Controller
    {
        private TenderContext db = new TenderContext();

        // GET: CurrencyBudgets
        public async Task<ActionResult> Index()
        {
            return View(await db.currencyBudgets.ToListAsync());
        }

        // GET: CurrencyBudgets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyBudget currencyBudget = await db.currencyBudgets.FindAsync(id);
            if (currencyBudget == null)
            {
                return HttpNotFound();
            }
            return View(currencyBudget);
        }

        // GET: CurrencyBudgets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyBudgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CurrencyBudgetID,ListCurrencyBudget")] CurrencyBudget currencyBudget)
        {
            if (ModelState.IsValid)
            {
                db.currencyBudgets.Add(currencyBudget);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(currencyBudget);
        }

        // GET: CurrencyBudgets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyBudget currencyBudget = await db.currencyBudgets.FindAsync(id);
            if (currencyBudget == null)
            {
                return HttpNotFound();
            }
            return View(currencyBudget);
        }

        // POST: CurrencyBudgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CurrencyBudgetID,ListCurrencyBudget")] CurrencyBudget currencyBudget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currencyBudget).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(currencyBudget);
        }

        // GET: CurrencyBudgets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyBudget currencyBudget = await db.currencyBudgets.FindAsync(id);
            if (currencyBudget == null)
            {
                return HttpNotFound();
            }
            return View(currencyBudget);
        }

        // POST: CurrencyBudgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CurrencyBudget currencyBudget = await db.currencyBudgets.FindAsync(id);
            db.currencyBudgets.Remove(currencyBudget);
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

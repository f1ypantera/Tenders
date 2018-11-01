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

     
        public async Task<ActionResult> Index()
        {
            return View(await db.currencyBudgets.ToListAsync());
        }

      
    
     
        public ActionResult Create()
        {
            return View();
        }

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

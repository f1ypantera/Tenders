using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tenders.Models
{
    public class TenderContext : DbContext
    {

        public TenderContext() : base("DefaultConnection") { }

        public DbSet<Tender> tenders { get; set; }
        public DbSet<OrgTender> orgTenders { get; set; }
        public DbSet<ViewTender> viewTenders { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CurrencyBudget> currencyBudgets { get; set; }



    }
}
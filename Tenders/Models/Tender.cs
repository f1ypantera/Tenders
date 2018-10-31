using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tenders.Models;
using System.ComponentModel.DataAnnotations;


namespace Tenders.Models
{
    public class Tender
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int TenderID { get; set; }
        public string SubjectTender { get; set; }
        public string DescriptionTender { get; set; }

        public int OrgTenderID { get; set; }
        public OrgTender OrgTender { get; set; }


        public int ViewTenderID { get; set; }
        public ViewTender ViewTender { get; set; }


        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int Budget { get; set; }

        public int CurrencyBudgetID { get; set; }
        public CurrencyBudget CurrencyBudget { get; set; }

        public DateTime date { get; set; }
        public string SponsorShip { get; set; }
    
            

    }
}
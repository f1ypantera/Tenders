using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tenders.Models;
using System.ComponentModel.DataAnnotations;

namespace Tenders.Models
{
    public class CurrencyBudget
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int CurrencyBudgetID { get; set; }
        [Display(Name = "Справочник валют")]
        public string ListCurrencyBudget { get; set; }
    }
}
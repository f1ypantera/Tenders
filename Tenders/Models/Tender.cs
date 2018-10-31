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
        [Display(Name = "Предмет тендера")]
        public string SubjectTender { get; set; }
        [Display(Name = "Описание тендера")]
        public string DescriptionTender { get; set; }

        [Display(Name = "Организатор тендера")]
        public int OrgTenderID { get; set; }
        
        public OrgTender OrgTender { get; set; }

        [Display(Name = "Вид тендера")]
        public int ViewTenderID { get; set; }
     
        public ViewTender ViewTender { get; set; }

        [Display(Name = "Категория/класификация тендера")]
        public int CategoryID { get; set; }
     
        public Category Category { get; set; }

        [Display(Name = "Начальная ставка")]
        public int Budget { get; set; }

        [Display(Name = "Валюта тендера")]
        public int CurrencyBudgetID { get; set; }
        [Display(Name = "Валюта тендера")]
        public CurrencyBudget CurrencyBudget { get; set; }

        [Display(Name = "Время")]
     
        public DateTime date
        {
            get
            {
                return DateTime.Now;
            }

            set
            {
               
            }
        }

        [Display(Name = "Спонсоры")]
        public string SponsorShip { get; set; }
    
            

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tenders.Models;
using System.ComponentModel.DataAnnotations;

namespace Tenders.Models
{
    public class ViewTender
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ViewTenderID { get; set; }
        public string ListViewTenders { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tenders.Models;
using System.ComponentModel.DataAnnotations;

namespace Tenders.Models
{
    public class Category
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int CategoryID { get; set; }
        public string ListCategory { get; set; }

    }
}
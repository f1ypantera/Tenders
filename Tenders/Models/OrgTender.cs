using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tenders.Models;
using System.ComponentModel.DataAnnotations;

namespace Tenders.Models
{
    public class OrgTender
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int OrgTenderID { get; set; }
        public string ListOrgTender { get; set; }
    }
}
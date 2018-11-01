using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenders.Models
{
    public class TenderListViewModel
    {
        public IEnumerable<Tender> Tenders { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
    }
}
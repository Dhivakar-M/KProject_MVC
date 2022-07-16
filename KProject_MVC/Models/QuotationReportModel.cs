using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KProject_MVC.Models
{
    public class QuotationReportModel
    {
        public string FromCompanyName { get; set; }
        public string FromEmail { get; set; }
        public DateTime FromDate { get; set; }
        public string ToCompanyName { get; set; }
        public string ToEmail { get; set; }
        public DateTime ToDate { get; set; }
        public List<PriceSummary1> PriceSummaryList {get; set; }
    }

    public class PriceSummary1
    {
        public int SerialNo { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int LumpSum { get; set; }
        public string Remarks { get; set; }
    }
}
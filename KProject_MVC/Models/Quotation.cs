using System.Collections.Generic;

namespace KProject_MVC.Models
{
    public class Quotation
    {
        public int QuotationId { get; set; }
        public string EnquiryDate { get; set; }
        public string EnquiryRefNumber { get; set; }
        public string SupplierName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public List<PriceSummary> PriceSummaryList { get; set; }
    }
}
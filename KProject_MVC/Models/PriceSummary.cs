namespace KProject_MVC.Models
{
    public class PriceSummary
    {
        public int PriceSummaryId { get; set; }
        public int? QuotationId { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Remarks { get; set; }
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketTracker.Data
{
    public class Sale
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BoughtPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SoldPrice { get; set; }
        public int? Shares { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DividendAmt { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
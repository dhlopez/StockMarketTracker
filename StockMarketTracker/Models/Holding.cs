using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketTracker
{
    public class Holding
    {
        public int Id { get; set; }
        public int Shares { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Average { get; set; }

        [ForeignKey("Ticker")]
        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }
    }
}
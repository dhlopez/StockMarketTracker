using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketTracker
{
    public class Ticker
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public DateTime? DateLastUpdated
        {
            get
            {
                return this.dateLastUpdate.HasValue
                   ? this.dateLastUpdate.Value
                   : new DateTime();
            }

            set { this.dateLastUpdate = value; }

        }

        private DateTime? dateLastUpdate = null;
    }
}
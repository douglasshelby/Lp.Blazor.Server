using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lp.Blazor.Server.Data.Models
{
    public record Order
    {
        public int RowId { get; set; }
        public string OrderId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Season => ToSeason(OrderDate);
        public DateTime ShipDate { get; set; }
        public string ShipMode { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Segment { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Sales { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Profit { get; set; }

        private string ToSeason(DateTime orderDate) => orderDate.Month switch
        {
            3 or 4 or 5 => "Spring",
            6 or 7 or 8 => "Summer",
            9 or 10 or 11 => "Fall",
            12 or 1 or 2 => "Winter",
            _ => throw new InvalidDataException($"Invalid month detected:{orderDate.Month}")
        };
    }
}
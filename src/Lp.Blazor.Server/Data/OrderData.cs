using CsvHelper;
using CsvHelper.Configuration;
using Lp.Blazor.Server.Data.Models;
using System.Globalization;

namespace Lp.Blazor.Server.Data
{
    public interface IOrderData
    {
        public void Load(string orderFileName);
        public IEnumerable<Order> GetOrders();
    }
    public class OrderData : IOrderData
    {
        private IEnumerable<Order> _orders = new List<Order>();

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public void Load(string fullOrderFilePath)
        {
            if (!File.Exists(fullOrderFilePath)) throw new FileNotFoundException(fullOrderFilePath);

            using var reader = new StreamReader(fullOrderFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<OrderMap>();
            _orders = csv.GetRecords<Order>().ToList();
        }
    }
    public sealed class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(m => m.RowId).Name("Row ID", "RowId");
            Map(m => m.OrderId).Name("Order ID", "OrderId");
            Map(m => m.OrderDate).Name("Order Date", "OrderDate");
            Map(m => m.ShipDate).Name("Ship Date", "ShipDate");
            Map(m => m.ShipMode).Name("Ship Mode", "ShipMode");
            Map(m => m.CustomerId).Name("Customer ID", "CustomerId");
            Map(m => m.CustomerName).Name("Customer Name", "CustomerName");
            Map(m => m.Segment).Name("Segment", "Segment");
            Map(m => m.Country).Name("Country", "Country");
            Map(m => m.City).Name("City", "City");
            Map(m => m.State).Name("State", "State");
            Map(m => m.PostalCode).Name("Postal Code", "PostalCode");
            Map(m => m.Region).Name("Region", "Region");
            Map(m => m.ProductId).Name("Product ID", "ProductId");
            Map(m => m.Category).Name("Category", "Category");
            Map(m => m.SubCategory).Name("Sub-Category", "SubCategory");
            Map(m => m.ProductName).Name("Product Name", "ProductName");
            Map(m => m.Sales).Name("Sales", "Sales");
            Map(m => m.Quantity).Name("Quantity", "Quantity");
            Map(m => m.Discount).Name("Discount", "Discount");
            Map(m => m.Profit).Name("Profit", "Profit");
        }
    }
}

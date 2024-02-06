using Lp.Blazor.Server.Data;

namespace Lp.Blazor.Server.UnitTests.Fixtures
{
    public class TestData
    {
        const string InputFileName = "Sample - Superstore.csv";
        public static OrderData GetOrderData()
        {
            var fullDataPath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\Fixtures\\{InputFileName}";
            var orderData = new OrderData();
            orderData.Load(fullDataPath);
            return orderData;
        }

    }
}

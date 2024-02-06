using FluentAssertions;
using Lp.Blazor.Server.UnitTests.Fixtures;

namespace LetsPave.Blazor.WebApp.UnitTests.Data;

public class OrderDataTests
{
   
    [Fact]
    public void FileLoadsSuccessfully()
    {
        var orderData = TestData.GetOrderData();
        orderData.GetOrders().Should().NotBeNullOrEmpty();
        orderData.GetOrders().Should().HaveCount(9994);
    }
}
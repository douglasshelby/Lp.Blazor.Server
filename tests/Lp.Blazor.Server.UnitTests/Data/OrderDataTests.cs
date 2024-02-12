using FluentAssertions;
using Lp.Blazor.Server.Data;
using Lp.Blazor.Server.Data.Models;
using Lp.Blazor.Server.UnitTests.Fixtures;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace LetsPave.Blazor.WebApp.UnitTests.Data;

public class OrderDataTests
{
    decimal salesGrandTotal = 2297200.8603M;
    decimal profitGrandTotal = 286397.0217M;
    long quantityGrandTotal = 37873;

    decimal fallSalesTotals = 860434.0014M;
    decimal fallProfitTotals = 104109.9431M;
    long fallQuantityTotals = 13941;

    decimal jan2014SalesTotals = 191859.4605M;
    decimal jan2014ProfitTotals = 21068.4836M;
    long jan2014QuantityTotals = 2792;

    OrderData orderData;

    const string fallFilter = "Season = \"Fall\"";
    const string jan2014Fitler = "OrderDate <= DateTime(\"2014-12-30\")";
    const string jan2014FallFilter = fallFilter + " AND " + jan2014Fitler;

    public OrderDataTests()
    {
        orderData = TestData.GetOrderData();
    }
    [Fact]
    public void FileLoadsSuccessfully()
    {
        
        orderData.GetOrders().Should().NotBeNullOrEmpty();
        orderData.GetOrders().Should().HaveCount(9994);
    }

    [Fact]
    public void FallTotalsVerification()
    {
        var fallSalesTotals = orderData.GetOrders().AsQueryable<Order>().Where(fallFilter).Sum(o=>o.Sales);
        var fallProfitTotals = orderData.GetOrders().AsQueryable<Order>().Where(fallFilter).Sum(o => o.Profit);
        var fallQuantityTotals = orderData.GetOrders().AsQueryable<Order>().Where(fallFilter).Sum(o => o.Quantity);
    }

    [Fact]
    public void Jan2014TotalsVerification()
    {
        var jan2014SalesTotals = orderData.GetOrders().AsQueryable<Order>().Where(jan2014Fitler).Sum(o => o.Sales);
        var jan2014ProfitTotals = orderData.GetOrders().AsQueryable<Order>().Where(jan2014Fitler).Sum(o => o.Profit);
        var jan2014QuantityTotals = orderData.GetOrders().AsQueryable<Order>().Where(jan2014Fitler).Sum(o => o.Quantity);
    }

    [Fact]
    public void Jan2014TFallTotalsVerification()
    {
        var jan2014SalesTotals = orderData.GetOrders().AsQueryable<Order>().Where(jan2014FallFilter).Sum(o => o.Sales);
        var jan2014ProfitTotals = orderData.GetOrders().AsQueryable<Order>().Where(jan2014FallFilter).Sum(o => o.Profit);
        var jan2014QuantityTotals = orderData.GetOrders().AsQueryable<Order>().Where(jan2014FallFilter).Sum(o => o.Quantity);
    }
}
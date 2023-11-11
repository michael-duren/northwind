using DataContext;
using Domain;

namespace UnitTests;

public class EntityModelTests
{
    [Fact]
    public void DatabaseConnectTest()
    {
        using NorthwindContext context = new();
        Assert.True(context.Database.CanConnect());
    }

    [Fact]
    public void CategoryCountTest()
    {
        using NorthwindContext context = new();

        const int expected = 8;
        int actual = context.Categories.Count();
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProductId1IsChaiTest()
    {
        using NorthwindContext context = new();

        const string expected = "Chai";

        Product? product = context.Products.Find(keyValues: 1);
        string actual = product?.ProductName ?? string.Empty;
        
        Assert.Equal(expected, actual);
    }
}
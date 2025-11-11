using NetArchTest.Rules;
using ShopLite.Application;
using ShopLite.Domain;
using ShopLite.Presentation.Controllers;
using Xunit;

namespace ShopLite.ArchTests;

public class ArchitectureTests
{
    [Fact]
    public void Domain_Should_Not_Depend_On_Others()
    {
        var result = Types.InAssembly(typeof(AssemblyMarker).Assembly)
            .Should().NotHaveDependencyOnAny("ShopLite.Application", "ShopLite.Infrastructure", "ShopLite.Presentation")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join("\n", result.FailingTypeNames));
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Presentation_Or_Infrastructure()
    {
        var result = Types.InAssembly(typeof(ShopLite.Application.AssemblyMarker).Assembly)
            .Should().NotHaveDependencyOnAny("ShopLite.Presentation", "ShopLite.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join("\n", result.FailingTypeNames));
    }

    [Fact]
    public void Presentation_Should_Not_Depend_On_Domain_Or_Infrastructure_Directly()
    {
        var result = Types.InAssembly(typeof(ProductsController).Assembly)
            .Should().NotHaveDependencyOnAny("ShopLite.Domain", "ShopLite.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join("\n", result.FailingTypeNames));
    }
}

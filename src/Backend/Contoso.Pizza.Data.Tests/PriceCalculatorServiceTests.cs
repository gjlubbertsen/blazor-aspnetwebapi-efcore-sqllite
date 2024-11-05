using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Contoso.Pizza.AdminApi.Models;

[TestFixture]
public class PriceCalculatorServiceTests
{
    private PriceCalculatorService _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new PriceCalculatorService();
    }
 
    [Test]
    public void PriceCalculated()
    {
        _sut.CalculatePrice(new PizzaEntity() {
            Name = "Test Pizza",
            Price = 0,
            Sauce = new SauceEntity { Price = 1 },
            Toppings = new List<ToppingEntity> {
                new ToppingEntity { Name = "A", Price = 2 },
                new ToppingEntity { Name = "B", Price = 2 }
            }
        }).Should().Be(10);
    }
}


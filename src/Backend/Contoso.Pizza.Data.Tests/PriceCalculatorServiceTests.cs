using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Extensions.Time.Testing;

namespace Contoso.Pizza.AdminApi.Models;

[TestFixture]
public class PriceCalculatorServiceTests
{
    private FakeTimeProvider _fakeTimeProvider = default!;
    private PriceCalculatorService _sut = default!;

    [SetUp]
    public void Setup()
    {
        _fakeTimeProvider = new FakeTimeProvider();
        _sut = new PriceCalculatorService(_fakeTimeProvider);
    }
 
    [Test]
    public void CalculatePrice_WithBasicPizza_CalculateToMinimumAmount()
    {
        _sut.CalculatePrice(new PizzaEntity
        {
            Name = "Test Pizza",
            Price = 2,
            Sauce = new() { Price = 1 },
            Toppings = [new () { Name = "A", Price = 2 }]
        }).Should().Be(10);
    }
}


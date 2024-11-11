using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Contoso.Pizza.AdminApi.Services;
using Contoso.Pizza.Data.Contracts;
using DM = Contoso.Pizza.Data.Models;

namespace Contoso.Pizza.AdminApi.Models;

[TestFixture]
public class PizzaServiceTest
{
     private IPriceCalculatorService _priceCalculatorService = default!;
    private IPizzaRepository _repo = default!;
    private PizzaValidator _sut = default!;

    [SetUp]
    public void Setup()
    {
        _priceCalculatorService = A.Fake<IPriceCalculatorService>();
        _repo = A.Fake<IPizzaRepository>();
        _sut = new PizzaValidator(_priceCalculatorService, _repo); 
    }
 
    [Test]
    public async Task CalculatePrice_WithBasicPizza_ReturnsMinimumAmount()
    {
        A.CallTo(() => _priceCalculatorService.CalculatePrice(A<PizzaEntity>._)).Returns(30);
        A.CallTo(() => _repo.GetAllAsync())
        .ReturnsLazily((c) => 
            Task.FromResult<IEnumerable<DM.Pizza>>(
                [
                    new DM.Pizza{Name = "Test Pizza", Price = 2,Sauce = new() { Name = "Sauce" }}
                ]
            ));

        var errors = await _sut.IsValidPizza(new PizzaEntity
        {
            Name = "Test Pizza",
            Price = 2,
            Sauce = new() { Price = 1 },
            Toppings = [new () { Name = "A", Price = 2 }]
        });
        errors.Should().Contain("Pizza name must be unique.");
    }
}


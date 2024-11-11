using Contoso.Pizza.AdminApi.Models;
using Contoso.Pizza.Data.Contracts;

namespace Contoso.Pizza.AdminApi.Services;

public interface IPizzaValidator
{
    Task<IReadOnlyCollection<string>> IsValidPizza(PizzaEntity pizza);
}

public class PizzaValidator(IPriceCalculatorService priceCalculatorService, IPizzaRepository repository) : IPizzaValidator
{
    private readonly IPriceCalculatorService _priceCalculatorService = priceCalculatorService;
    private readonly IPizzaRepository _repository = repository;

    public async Task<IReadOnlyCollection<string>> IsValidPizza(PizzaEntity pizza)
    {
        var validationErrors = new List<string>();

        if (string.IsNullOrWhiteSpace(pizza.Name))
        {
            validationErrors.Add("Pizza name cannot be empty.");
        }

        if (pizza.Toppings == null || !pizza.Toppings.Any())
        {
            validationErrors.Add("Pizza must have at least one topping.");
        }

        var totalPrice = _priceCalculatorService.CalculatePrice(pizza);

        if (totalPrice < 5 || totalPrice > 50)
        {
            validationErrors.Add("Total price of the pizza must be between $5 and $50.");
        }

        var existingPizzas = await _repository.GetAllAsync();
        if (existingPizzas.Any(p => p.Name.Equals(pizza.Name, StringComparison.OrdinalIgnoreCase)))
        {
            validationErrors.Add("Pizza name must be unique.");
        }

        return validationErrors;
    }
}

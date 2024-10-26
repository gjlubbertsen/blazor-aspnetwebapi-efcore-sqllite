using AutoMapper;
using Contoso.Pizza.AdminApi.Models;
using Contoso.Pizza.AdminApi.Services.Contracts;
using Contoso.Pizza.Data.Contracts;
using DM = Contoso.Pizza.Data.Models;

namespace Contoso.Pizza.AdminApi.Services;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _repository;
    private readonly IMapper _mapper;

    public PizzaService(IPizzaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PizzaEntity>> GetAllAsync()
    {
        var pizzas = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PizzaEntity>>(pizzas);
    }

    public async Task<PizzaEntity?> GetByIdAsync(Guid id)
    {
        var pizza = await _repository.GetByIdAsync(id);
        return _mapper.Map<PizzaEntity>(pizza);
    }

    public async Task<PizzaEntity> AddAsync(PizzaEntity entity)
    {
        if (!IsValidPizza(entity, out var validationErrors))
        {
            throw new ArgumentException(string.Join("; ", validationErrors));
        }
        var newPizza = _mapper.Map<DM.Pizza>(entity);
        await _repository.AddAsync(newPizza);
        return _mapper.Map<PizzaEntity>(newPizza);
    }

    public async Task<int> UpdateAsync(PizzaEntity entity)
    {
        if (!IsValidPizza(entity, out var validationErrors))
        {
            throw new ArgumentException(string.Join("; ", validationErrors));
        }
        var pizzaToUpdate = _mapper.Map<DM.Pizza>(entity);
        return await _repository.UpdateAsync(pizzaToUpdate);
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }


     private bool IsValidPizza(PizzaEntity pizza, out List<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(pizza.Name))
            {
                validationErrors.Add("Pizza name cannot be empty.");
            }

            if (pizza.Toppings == null || !pizza.Toppings.Any())
            {
                validationErrors.Add("Pizza must have at least one topping.");
            }

            /*var totalPrice = pizza.Sauce?.Price ?? 0;
            foreach (var topping in pizza.Toppings)
            {
                totalPrice += topping.Price;
            }

            if (totalPrice < 5 || totalPrice > 50)
            {
                validationErrors.Add("Total price of the pizza must be between $5 and $50.");
            }*/

            var existingPizzas = _repository.GetAllAsync().Result;
            if (existingPizzas.Any(p => p.Name.Equals(pizza.Name, StringComparison.OrdinalIgnoreCase)))
            {
                validationErrors.Add("Pizza name must be unique.");
            }

            return !validationErrors.Any();
        }
}

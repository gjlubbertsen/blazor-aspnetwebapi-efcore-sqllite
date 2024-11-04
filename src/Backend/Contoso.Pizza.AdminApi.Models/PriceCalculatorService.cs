namespace Contoso.Pizza.AdminApi.Models
{

    public interface IPriceCalculatorService
    {
        decimal CalculatePrice(PizzaEntity pizza);
    }

    public class PriceCalculatorService : IPriceCalculatorService
    {
        public decimal CalculatePrice(PizzaEntity pizza)
        {
            var price = pizza.Price;

            // Add sauce price
            if (pizza.Sauce != null)
            {
                price += pizza.Sauce.Price;

                // Extra charge for vegan sauce
                if (pizza.Sauce.IsVegan)
                {
                    price += 2.0m; // Extra charge for vegan sauce
                }
            }

            // Add toppings price
            if (pizza.Toppings != null)
            {
                var toppingsPrice = pizza.Toppings.Select(t => t.Price).Sum();

                // Discount for more than 2 toppings
                if (pizza.Toppings.Count > 2)
                {
                    toppingsPrice *= 0.7m; // 30% discount for more than 2 toppings
                }

                price += toppingsPrice;
            }

            // Discount if total price is above 18
            if (price > 18.0m)
            {
                price *= 0.9m; // 10% discount for total price above 18
            }

            // Ensure minimum price
            if (price < 10.0m)
            {
                price = 10.0m; // Minimum price
            }
            
            return price;
        }
    }
}
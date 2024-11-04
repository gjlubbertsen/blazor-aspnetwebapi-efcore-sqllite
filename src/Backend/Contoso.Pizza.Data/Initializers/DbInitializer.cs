using Contoso.Pizza.Data.Models;
using DM = Contoso.Pizza.Data.Models;

namespace Contoso.Pizza.Data.Initializers;

public static class DbInitializer
{
    public static void Initialize(ContosoPizzaDataContext context)
    {
        if(context.Pizza.Any()
           && context.Toppings.Any()
           && context.Sauces.Any())
        {
            return;
        }

        var pepperoniTopping = new Topping { Name = "Pepperoni", Calories = 130, Price = 3.00m};
        var sausageTopping = new Topping { Name = "Sausage", Calories = 100, Price = 3.00m };
        var hamTopping = new Topping { Name = "Ham", Calories = 70, Price = 3.00m };
        var chickenTopping = new Topping { Name = "Chicken", Calories = 50, Price = 3.50m };
        var pineappleTopping = new Topping { Name = "Pineapple", Calories = 75, Price = 2.00m };

        var tomatoSauce = new Sauce { Name = "Tomato", IsVegan = true, Price = 1.00m };
        var alfredoSauce = new Sauce { Name = "Alfredo", IsVegan = false, Price = 2.00m };

        var pizzas = new DM.Pizza[]
            {
                new DM.Pizza
                    {
                        Name = "Meat Lovers",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pepperoniTopping,
                                sausageTopping,
                                hamTopping,
                                chickenTopping
                            },
                        Price = 15.00m
                    },
                new DM.Pizza
                    {
                        Name = "Hawaiian",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pineappleTopping,
                                hamTopping
                            },
                        Price = 12.00m
                    },
                new DM.Pizza
                    {
                        Name="Alfredo Chicken",
                        Sauce = alfredoSauce,
                        Toppings = new List<Topping>
                            {
                                chickenTopping
                            },
                        Price = 11.00m
                        }
            };

        context.Pizza.AddRange(pizzas);
        context.SaveChanges();
    }
}

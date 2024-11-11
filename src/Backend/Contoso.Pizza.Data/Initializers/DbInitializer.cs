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

        var pepperoniTopping = new Topping { Name = "Pepperoni", Calories = 130, Price = 1.85m};
        var sausageTopping = new Topping { Name = "Sausage", Calories = 100, Price = 2.15m };
        var hamTopping = new Topping { Name = "Ham", Calories = 70, Price = 2.10m };
        var chickenTopping = new Topping { Name = "Chicken", Calories = 50, Price = 2.05m };
        var pineappleTopping = new Topping { Name = "Pineapple", Calories = 75, Price = 1.75m };
        var mushroomTopping = new Topping { Name = "Mushroom", Calories = 20, Price = 1.50m };
        var bellPepperTopping = new Topping { Name = "Bell Pepper", Calories = 15, Price = 1.25m };
        var onionTopping = new Topping { Name = "Onion", Calories = 10, Price = 1.00m };

        var spicyMarinara = new Sauce { Name = "Spicy Marinara", IsVegan = true, Price = 1.50m };
        var garlicParmesan = new Sauce { Name = "Garlic Parmesan", IsVegan = false, Price = 2.50m };
        var tomatoSauce = new Sauce { Name = "Herbed Tomato", IsVegan = true, Price = 1.00m };
        var alfredoSauce = new Sauce { Name = "Creamy Alfredo", IsVegan = false, Price = 2.00m };
        var pestoSauce = new Sauce { Name = "Pesto", IsVegan = true, Price = 2.00m };
        var bbqSauce = new Sauce { Name = "BBQ", IsVegan = true, Price = 1.75m };

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
                                hamTopping,
                                pineappleTopping
                            },
                        Price = 12.00m
                    },
                new DM.Pizza
                    {
                        Name = "Chicken Alfredo",
                        Sauce = alfredoSauce,
                        Toppings = new List<Topping>
                            {
                                chickenTopping
                            },
                        Price = 13.00m
                    },
                new DM.Pizza
                    {
                        Name = "Veggie Delight",
                        Sauce = spicyMarinara,
                        Toppings = new List<Topping>
                            {
                                pineappleTopping,
                                mushroomTopping,
                                bellPepperTopping,
                                onionTopping
                            },
                        Price = 11.00m
                    },
                new DM.Pizza
                    {
                        Name = "Garlic Chicken",
                        Sauce = garlicParmesan,
                        Toppings = new List<Topping>
                            {
                                chickenTopping
                            },
                        Price = 14.00m
                    },
                new DM.Pizza
                    {
                        Name = "BBQ Chicken",
                        Sauce = bbqSauce,
                        Toppings = new List<Topping>
                            {
                                chickenTopping,
                                onionTopping
                            },
                        Price = 14.00m
                    },
                new DM.Pizza
                    {
                        Name = "Pesto Veggie",
                        Sauce = pestoSauce,
                        Toppings = new List<Topping>
                            {
                                mushroomTopping,
                                bellPepperTopping,
                                onionTopping
                            },
                        Price = 13.00m
                    }
            };

        context.Pizza.AddRange(pizzas);
        context.SaveChanges();
    }
}

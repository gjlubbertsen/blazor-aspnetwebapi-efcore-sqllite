using Contoso.Pizza.AdminApi.Models;
using Contoso.Pizza.AdminUI.Services;
using Contoso.Pizza.AdminUI.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Contoso.Pizza.AdminUI.Components.Pages.Pizza;

public partial class PizzaUpsertPanel
{
    [Inject]
    ISauceService SauceService { get; set; } = default!;
    
    [Inject]
    IToppingService ToppingService { get; set; } = default!;

    [Inject]
    IPriceCalculatorService PriceCalculator { get; set; } = default!;
    
    [Parameter]
    public PizzaEntity Content { get; set; } = default!;

    IEnumerable<SauceEntity>? _sauces;
    List<ToppingEntity>? _toppings = [];
    bool isBusy;
    decimal _price;

    protected override async Task OnInitializedAsync()
    {
        isBusy = true;        
        _sauces = await SauceService.GetAllSaucesAsync();
        Content.Sauce = _sauces.FirstOrDefault();
        _toppings = (await ToppingService.GetAllToppingsAsync()).ToList();
        CalculatePrice();
        isBusy = false;
    }

    private void CalculatePrice()
    {
        _price = PriceCalculator.CalculatePrice(Content);
    }

    protected void OnToppingSelected(ToppingEntity item, bool selected)
    {
        if(selected)
        {
            Content.Toppings!.Add(item);
        }
        else
        {
            Content.Toppings!.Remove(item);
        }
        CalculatePrice();
    }


    protected void SauceSelected()
    {
        CalculatePrice();
    }
    

    public string PriceDisplay
    {
        get => Content.Price.ToString("0.00");
        set
        {
            if (decimal.TryParse(value, out var number))
            {
                Content.Price = Math.Round(number, 2);
                CalculatePrice();
            }
        }
    }
}
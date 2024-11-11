# Unit Testing with C# 

Deze solution is bedoelt om te laten zien hoe je unit tests kan schrijven in C#.

## Applicatie
Dit is in een voorbeeld app die opgestart kan worden door in vscode de task `Start Full Stack` te runnen.

## Screenshots
Home Page

<img src="./assets/home.png" width="400px">

Sauce Listing

<img src="./assets/pizzas-listing.png" width="400px">

Pizza Upsert

<img src="./assets/pizza-upsert.png" width="400px">

Sauce Delete

<img src="./assets/sauce-delete.png" width="400px">

# Credits go to:
[https://github.com/lohithgn/blazor-aspnetwebapi-efcore-sample]

# Unit Testing

## Taak1 - Unit Tests schrijven voor de PriceCalculatorService
Open de PriceCalculatorService en kijk naar de business logic die erin zit. Deze zou je met de hand vanuit de UI kunnen testen, maar dat is niet schaalbaar. Daarom gaan we unit tests schrijven.
* In de file `PriceCalculatorServiceTests.cs` staat de setup voor de tests. 

<img src="./assets/run-tests.png" width="400px">

## Taak2 - Sesonal Discount
In PriceCalculatorService.cs enable de seasonal discount. 

<img src="./assets/enable-seasonal.png" width="400px">

Voeg een nieuwe test toe die kijkt of de seasonal discount werkt. 
De seasonal discount is 20% korting op de prijs van de pizza in november. 
```csharp	
    FakeTimeProvider fake = new();
    fake.SetUtcNow(new DateTimeOffset(new DateTime(2004, 8, 17)));
```

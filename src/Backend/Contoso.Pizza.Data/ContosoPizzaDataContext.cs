using Contoso.Pizza.Data.Configutations;
using Contoso.Pizza.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using DM = Contoso.Pizza.Data.Models;

namespace Contoso.Pizza.Data;


public class ContosoPizzaDataContext : DbContext , IDesignTimeDbContextFactory<ContosoPizzaDataContext> 
{
    public DbSet<Sauce> Sauces { get; set; }
    public DbSet<DM.Pizza> Pizza { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    public string DbPath { get; }


    public ContosoPizzaDataContext()
    {
        DbPath = GetDbPath();
    }

    public ContosoPizzaDataContext(DbContextOptions<ContosoPizzaDataContext> options) 
        : base(options) {       
            DbPath = GetDbPath();
            Console.WriteLine($"DbPath: {DbPath}");
        }

    private string GetDbPath(){
        var path = Directory.GetCurrentDirectory();
        path = path.Substring(0, path.IndexOf("\\src\\")+5);
    
        return System.IO.Path.Join(path, "pizza.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new SauceEntityConfiguration().Configure(modelBuilder.Entity<Sauce>());
        new PizzaEntityConfiguration().Configure(modelBuilder.Entity<DM.Pizza>());
        new ToppingEntityConfiguration().Configure(modelBuilder.Entity<Topping>());
        new PizzaToppingEntityConfigration().Configure(modelBuilder.Entity<PizzaTopping>());
    }

    public ContosoPizzaDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ContosoPizzaDataContext>();
         optionsBuilder.UseSqlite($"Data Source={DbPath}");

        return new ContosoPizzaDataContext(optionsBuilder.Options);
    }
}

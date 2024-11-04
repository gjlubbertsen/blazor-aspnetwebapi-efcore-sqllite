namespace Contoso.Pizza.AdminApi.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }

    public decimal Price { get; set; }

    public DateTime? Modified { get; set; }
}

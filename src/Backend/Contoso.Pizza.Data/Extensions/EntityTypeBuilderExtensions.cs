using Contoso.Pizza.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Pizza.Data.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<T> ConfigureBaseEntity<T>(this EntityTypeBuilder<T> builder) 
        where T : BaseModel
    {
        builder.HasKey(e => e.Id);

        builder.Property(s => s.Created)
            .HasColumnType("datetime2")
            .HasDefaultValueSql("date()");

        builder.Property(s => s.Modified)
            .HasColumnType("datetime2");

        builder.Property(s => s.Price)
            .HasColumnType("decimal(18,2)");

        return builder;
    }
}

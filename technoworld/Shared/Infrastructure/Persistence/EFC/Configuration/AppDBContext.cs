using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using technoworld.Logistics.Domain.Model.Aggregates;

namespace technoworld.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Begin BoundedContext Model
        /*
        builder.Entity<Company>().HasKey(c=> c.Id);
        builder.Entity<Company>().Property(c=> c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Company>().Property(c=> c.Name).IsRequired().HasMaxLength(30);
        */
        builder.Entity<Inventory>().HasKey(c => c.Id);
        builder.Entity<Inventory>().Property(c=> c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Inventory>().Property(c=> c.ProductId).IsRequired();
        builder.Entity<Inventory>().Property(c=> c.WarehouseId).IsRequired();
        builder.Entity<Inventory>().Property(c=> c.CurrentStock).IsRequired();
        builder .Entity<Inventory>().Property(c=> c.MinimumStock).IsRequired();
        builder.Entity<Inventory>().Property(c=> c.InventoryName).HasMaxLength(30);
        builder.Entity<Inventory>().Property(c=> c.CompanyId).IsRequired();
        
        /*
        builder.Entity<Company>()
            .HasMany(c=> c.Inventories)
            .WithOne(i=> i.Company)
            .HasForeignKey(i=> i.CompanyId)
            .HasPrincipalKey(c=> c.Id);
            */
        
        // End BoundedContext Model
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}
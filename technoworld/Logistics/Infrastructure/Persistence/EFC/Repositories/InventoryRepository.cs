using Microsoft.EntityFrameworkCore;
using technoworld.Logistics.Domain.Model.Aggregates;
using technoworld.Logistics.Domain.Repositories;
using technoworld.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using technoworld.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace technoworld.Logistics.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDBContext context):BaseRepository<Inventory>(context),
    IInventoryRepository
{
    public async Task<bool> ExistsByProductIdAndWarehouseIdAsync (int productId, int warehouseId)
    {
        return await Context.Set<Inventory>()
            .AnyAsync(inventory => inventory.ProductId == productId && inventory.WarehouseId == warehouseId);
    }

    public async Task<bool> ExistsByCompanyIdAndInventoryNameAsync(int companyId, string inventoryName)
    {
        return await Context.Set<Inventory>()
            .AnyAsync(inventory => inventory.CompanyId == companyId && inventory.InventoryName == inventoryName);
    }

}
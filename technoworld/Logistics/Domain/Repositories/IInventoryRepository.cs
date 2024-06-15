using technoworld.Logistics.Domain.Model.Aggregates;
using technoworld.Shared.Domain.Repositories;

namespace technoworld.Logistics.Domain.Repositories;

public interface IInventoryRepository: IBaseRepository<Inventory>
{
    Task<bool> ExistsByProductIdAndWarehouseIdAsync(int productId, int warehouseId);
    Task<bool> ExistsByCompanyIdAndInventoryNameAsync(int companyId, string inventoryName);

}
using technoworld.Logistics.Domain.Model.Aggregates;
using technoworld.Logistics.Interfaces.REST.Resources;

namespace technoworld.Logistics.Interfaces.REST.Transform;

public class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToResourceFromEntity(Inventory entity)
    {
        return new InventoryResource(entity.Id, entity.ProductId, entity.WarehouseId, entity.MinimumStock, entity.CurrentStock,entity.InventoryName ,entity.CompanyId);
    }
}
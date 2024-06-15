using technoworld.Logistics.Domain.Model.Commands;
using technoworld.Logistics.Interfaces.REST.Resources;

namespace technoworld.Logistics.Interfaces.REST.Transform;

public class CreateInventoryCommandFromResourceAssembler
{
    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource)
    {
        return new CreateInventoryCommand(resource.ProductId, resource.WarehouseId, resource.MinimumStock, resource.CurrentStock, resource.InventoryName,resource.CompanyId);
    }
}
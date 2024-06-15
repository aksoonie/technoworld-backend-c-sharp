using technoworld.Logistics.Domain.Model.Aggregates;
using technoworld.Logistics.Domain.Model.Commands;
using technoworld.Logistics.Domain.Model.ValueObjects;
using technoworld.Logistics.Domain.Repositories;
using technoworld.Logistics.Domain.Services;
using technoworld.Shared.Domain.Repositories;

namespace technoworld.Logistics.Application.Internal.CommandServices;

public class InventoryCommandService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork) : IInventoryCommandService
{
    /// <summary>
    /// Handle Create Inventory Command
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        if (command.MinimumStock < 1)
        {
            throw new Exception("Minimum stock must be greater than or equal to 1");
        }
        if (command.CurrentStock < command.MinimumStock)
        {
            throw new Exception("Current stock must be greater than or equal to minimum stock");
        }
        //verifica si el companyId es un valor valido
        if (!Enum.IsDefined(typeof(ECompany), command.CompanyId))
        {
            throw new Exception("Invalid Company Id");
        }
        // Check if an inventory with the same ProductId and WarehouseId already exists
        var existsInventoryByProductIdAndWarehouseId = await inventoryRepository.ExistsByProductIdAndWarehouseIdAsync(command.ProductId, command.WarehouseId);
        if (existsInventoryByProductIdAndWarehouseId) throw new Exception("Inventory with the same Product Id and Warehouse Id already exists");
        // Check if an inventory with the same CategoryId and inventoryName already exists
        var existsInventoryByCategory = await inventoryRepository.ExistsByCompanyIdAndInventoryNameAsync(command.CompanyId, command.InventoryName);
        if (existsInventoryByCategory) throw new Exception("Inventory with the same Company Id and Inventory Name already exists");

        var inventory = new Inventory(command.ProductId, command.WarehouseId, command.MinimumStock, command.CurrentStock, command.InventoryName,command.CompanyId);
        await inventoryRepository.AddAsync(inventory);
        await unitOfWork.CompleteAsync();
        return inventory;
    }
}
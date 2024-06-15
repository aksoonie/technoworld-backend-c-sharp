namespace technoworld.Logistics.Domain.Model.Commands;

public record CreateInventoryCommand(
    int ProductId,
    int WarehouseId,
    int MinimumStock,
    int CurrentStock,
    string InventoryName,
    int CompanyId);
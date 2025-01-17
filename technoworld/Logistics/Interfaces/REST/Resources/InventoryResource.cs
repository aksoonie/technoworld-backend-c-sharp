namespace technoworld.Logistics.Interfaces.REST.Resources;

public record InventoryResource (
    int Id,
    int ProductId,
    int WarehouseId,
    int MinimumStock,
    int CurrentStock,
    string InventoryName,
    int CompanyId);
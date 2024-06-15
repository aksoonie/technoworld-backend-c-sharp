namespace technoworld.Logistics.Domain.Model.Aggregates;

public partial class Inventory
{
    public int Id { get; }
    public int ProductId { get; private set; }
    
    public int WarehouseId { get; private set; }
    public int MinimumStock { get; private set; }
    public int CurrentStock { get; private set; }
    public string InventoryName { get; private set; }
    public int CompanyId { get; private set; }
   
    public Inventory(int productId, int warehouseId, int minimumStock, int currentStock,string inventoryName, int companyId)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        MinimumStock = minimumStock;
        CurrentStock = currentStock;
        InventoryName = inventoryName;
        CompanyId = companyId;
    }
}
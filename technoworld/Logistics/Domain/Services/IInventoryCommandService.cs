using technoworld.Logistics.Domain.Model.Aggregates;
using technoworld.Logistics.Domain.Model.Commands;

namespace technoworld.Logistics.Domain.Services;

public interface IInventoryCommandService
{
    Task<Inventory?> Handle(CreateInventoryCommand command);
}
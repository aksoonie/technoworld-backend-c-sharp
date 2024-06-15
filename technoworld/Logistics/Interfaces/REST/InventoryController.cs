using Microsoft.AspNetCore.Mvc;
using technoworld.Logistics.Domain.Services;
using technoworld.Logistics.Interfaces.REST.Resources;
using technoworld.Logistics.Interfaces.REST.Transform;

namespace technoworld.Logistics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class InventoryController (IInventoryCommandService inventoryCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryResource createInventoryResource)
    {
        var createInventoryCommand =
            CreateInventoryCommandFromResourceAssembler
                .ToCommandFromResource(createInventoryResource);
        var inventory = await inventoryCommandService.Handle(createInventoryCommand);
        if (inventory is null) return BadRequest();
        var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return CreatedAtAction(nameof(CreateInventory), new { inventory = resource.Id }, resource);
        
    }
}
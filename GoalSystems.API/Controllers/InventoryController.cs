using GoalSystems.Domain.Business;
using GoalSystems.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoalSystems.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IInventoryService _inventoryService;

    public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
    {
        _logger = logger;
        _inventoryService = inventoryService;
    }

    /// <summary>
    /// Gets the items
    /// </summary>
    /// <returns></returns>
    [HttpGet("/items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Item>>> Get()
    {
        var items = await _inventoryService.GetItems();

        return Ok(items);
    }

    /// <summary>
    /// Adds a new item
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost("/items/create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Item>> CreateItem(Item item)
    {
        await _inventoryService.Add(item);
        _logger.LogInformation("Item with name {itemName} has been created into the database.", item.Name);
        return CreatedAtAction(nameof(CreateItem), item);
    }

    /// <summary>
    /// Remove an existing item by name
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns></returns>
    [HttpDelete("/items/delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteItemByName(string itemName) {
        await _inventoryService.Remove(itemName);
        _logger.LogInformation("Item with name {itemName} has been removed from the database.", itemName);
        return Ok();
    }
}

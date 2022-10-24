
using FluentAssertions;
using GoalSystems.API.Controllers;
using GoalSystems.Domain.Business;
using GoalSystems.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace GoalSystems.UnitTests;

public class ItemsControllerTests
{
    private readonly Mock<IInventoryService> inventoryServiceStub = new();
    private readonly Mock<ILogger<InventoryController>> loggerStub = new();

    [Fact]
    public async Task AddItem_WithItemToAdd_ReturnsAddedItem()
    {
        // Arrange
        var itemToAdd = new Item() { 
            Name = "Tolom",
            Type = "Mild",
            ExpirationDate = DateTime.Now,
        };

        var controller = new InventoryController(loggerStub.Object, inventoryServiceStub.Object); 

        // Act
        var result = await controller.CreateItem(itemToAdd);


        // Assert
        var createdItem = (result?.Result as CreatedAtActionResult).Value;
        createdItem.Should().BeEquivalentTo(itemToAdd);

    }

    [Fact]
    public async Task RemoveItem_WithItemToRemove_ReturnsOk()
    {
        // Arrange
        var itemName = "Tolom";

        var controller = new InventoryController(loggerStub.Object, inventoryServiceStub.Object);

        // Act
        var result = await controller.DeleteItemByName(itemName);


        // Assert
        result.Should().BeOfType<OkResult>();

    }
}
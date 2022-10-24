using GoalSystems.Domain.Business;
using GoalSystems.Domain.Entities;

namespace GoalSystems.Infrastructure.Services
{
    /// <summary>
    /// Service for manage the items repository
    /// </summary>
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        { 
            _inventoryRepository = inventoryRepository;
        }

        /// <summary>
        /// Gets the items
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetItems()
        {
            return await _inventoryRepository.GetItems();
        }

        /// <summary>
        /// Adds a new item
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns></returns>
        public async Task Add(Item item) { 
            await _inventoryRepository.Add(item);
        }

        /// <summary>
        /// Remove an item by name
        /// </summary>
        /// <param name="itemName">string</param>
        /// <returns></returns>
        public async Task Remove(string itemName) { 
            await _inventoryRepository.Remove(itemName);
        }
    }
}

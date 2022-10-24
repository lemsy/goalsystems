using GoalSystems.Domain.Business;
using GoalSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoalSystems.Infrastructure.Data
{
    /// <summary>
    /// Repository of items
    /// </summary>
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryContext context;
        public InventoryRepository(InventoryContext inventoryContext) {

            context = inventoryContext;
        }

        /// <summary>
        /// Gets the items
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetItems()
        {
            var items = await context.Items.ToListAsync();
            return items;
        }

        /// <summary>
        /// Adds a new item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Add(Item item) {
            await context.Items.AddAsync(item);

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove an item by name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public async Task Remove(string itemName) {
            var item = await context.Items.SingleAsync(x => x.Name == itemName);
            context.Items.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}

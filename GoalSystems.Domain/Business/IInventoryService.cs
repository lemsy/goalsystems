using GoalSystems.Domain.Entities;


namespace GoalSystems.Domain.Business
{
    /// <summary>
    /// Interface for manage the items of the inventory
    /// </summary>
    public interface IInventoryService
    {
        Task<List<Item>> GetItems();
        Task Add(Item item);
        Task Remove(string itemName);
    }
}

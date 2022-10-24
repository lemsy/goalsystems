

using GoalSystems.Domain.Entities;

namespace GoalSystems.Domain.Business
{
    /// <summary>
    /// Interface for manage the items in a data repository
    /// </summary>
    public interface IInventoryRepository
    {
        Task<List<Item>> GetItems();

        Task Add(Item item);
        Task Remove(string name);
    }
}

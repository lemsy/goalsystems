
using System.ComponentModel.DataAnnotations;

namespace GoalSystems.Domain.Entities
{
    /// <summary>
    /// Represents an item of the inventory
    /// </summary>
    public class Item
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
        
    }
}

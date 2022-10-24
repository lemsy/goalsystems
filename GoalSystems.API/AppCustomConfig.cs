using GoalSystems.Domain.Entities;
using GoalSystems.Infrastructure.Data;

namespace GoalSystems.API
{
    
    public static class AppCustomConfig
    {
        public static void InitializeInMemoryDatabase(WebApplication app) {
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<InventoryContext>();


            var items = new List<Item>() {

                    new Item(){  Name = "Tolom", Type = "Milk", ExpirationDate = DateTime.Now  },
                    new Item(){  Name = "Beef", Type = "Meal" , ExpirationDate = DateTime.Now.AddDays(1) },
                    new Item(){  Name = "Malt", Type = "Beverage",  ExpirationDate = DateTime.Now.AddDays(2) },
                };

            context.Items.AddRange(items);

            context.SaveChanges();
        }
    }
}

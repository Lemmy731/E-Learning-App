using E_Learn.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace E_learning.Extension
{
    public class ConfigCon
    {
        public static async void Initilize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();  
            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILogger<Program>>();
            try
            {
                var context = services.GetRequiredService<StoreContext>(); 
                await context.Database.MigrateAsync();
                await StoreContextSeed.Seed(context, logger);
            }
            catch (Exception ex) 
            {
               
                logger.LogError(ex, "something happening during migration");
            }
           
        }
    }
}

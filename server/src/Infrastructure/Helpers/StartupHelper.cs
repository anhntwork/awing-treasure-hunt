using Infrastructure.Data;
using Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Helpers
{
    public static class StartupHelper
    {
        public static void RegisterDbContextFactories(this IServiceCollection services, IConfiguration configuration)
        {
            const string DAILY_HISTORY_TABLE = "[daily_history]";
            const string REALTIME_HISTORY_TABLE = "[rt_daily_history_ohlc]";
            const string RT_INSTRUMENTPRICE_TABLE = "[rt_InstrumentPrice]";
            const string INSTRUMENTPRICE_TABLE = "[InstrumentPrice]";


            // ReplaceService, WithRealtimeConnectionString, WithRealtimeTableReplacer serves to change the db and table names when UseRealtimeModel in the DbContext class is set to true. 
            services.AddPooledDbContextFactory<TreasureHuntDbContext>(
                options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                        .ReplaceService<IModelCacheKeyFactory, DynamicRealtimeTableModelCacheKeyFactory>()
                        .WithRealtimeConnectionString((sharkContext) => configuration.GetConnectionString("RealtimeDb"))
                        .WithRealtimeTableReplacer((originalQuery) =>
                                    originalQuery
                                    .Replace(DAILY_HISTORY_TABLE, REALTIME_HISTORY_TABLE, System.StringComparison.InvariantCultureIgnoreCase)
                                    .Replace(INSTRUMENTPRICE_TABLE, RT_INSTRUMENTPRICE_TABLE, System.StringComparison.InvariantCultureIgnoreCase)
                        )

            );
        }
    }
}

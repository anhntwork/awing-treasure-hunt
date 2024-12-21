using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories
{
    public class DynamicRealtimeTableModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context, bool designTime)
            => context is TreasureHuntDbContext projectBaseContext
                ? (context.GetType(), projectBaseContext.UseRealtimeModel, designTime)
                : context.GetType();
    }
}

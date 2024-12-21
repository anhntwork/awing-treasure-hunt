using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories
{
    public class DynamicConnectionIntercepter : DbConnectionInterceptor
    {
        private readonly Func<TreasureHuntDbContext, string> _getConnectionString;
        public DynamicConnectionIntercepter(Func<TreasureHuntDbContext, string> getConnectionString)
        {
            _getConnectionString = getConnectionString ?? throw new ArgumentNullException(nameof(getConnectionString));
        }
        public override InterceptionResult ConnectionOpening(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
        {
            if (IsUsingRealtimeDb(eventData.Context))
            {
                var sqlConnection = (SqlConnection)connection;
                sqlConnection.ConnectionString = _getConnectionString(eventData.Context as TreasureHuntDbContext);
            }

            return base.ConnectionOpening(connection, eventData, result);
        }

        public override async ValueTask<InterceptionResult> ConnectionOpeningAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
        {
            if (IsUsingRealtimeDb(eventData.Context))
            {
                var sqlConnection = (SqlConnection)connection;
                sqlConnection.ConnectionString = _getConnectionString(eventData.Context as TreasureHuntDbContext);
            }

            return await base.ConnectionOpeningAsync(connection, eventData, result, cancellationToken);
        }

        private static bool IsUsingRealtimeDb(DbContext dbContext) => (dbContext as TreasureHuntDbContext)?.UseRealtimeModel ?? false;
    }

    public static class RealtimeDbConnectionExtentions
    {
        public static Microsoft.EntityFrameworkCore.DbContextOptionsBuilder WithRealtimeConnectionString(
            [System.Diagnostics.CodeAnalysis.NotNull] this Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder,
            Func<TreasureHuntDbContext, string> getSqlConnectionString)
        {
            var interceptor = new DynamicConnectionIntercepter(getSqlConnectionString);
            optionsBuilder.AddInterceptors(interceptor);
            return optionsBuilder;
        }
    }
}

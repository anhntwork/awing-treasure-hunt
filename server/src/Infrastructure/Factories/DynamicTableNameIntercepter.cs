using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Infrastructure.Factories
{
    public class DynamicTableNameIntercepter : DbCommandInterceptor
    {
        private readonly Func<string, string> _func;

        public DynamicTableNameIntercepter(Func<string, string> func)
        {
            _func = func;
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            if (IsUsingRealtimeDb(eventData.Context))
            {
                var newCommandText = _func != null
                    ? _func(command.CommandText)
                    : null;

                if (!string.IsNullOrWhiteSpace(newCommandText))
                {
                    command.CommandText = newCommandText;
                }
            }

            return base.ReaderExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            if (IsUsingRealtimeDb(eventData.Context))
            {
                var newCommandText = _func != null
                    ? _func(command.CommandText)
                    : null;

                if (!string.IsNullOrWhiteSpace(newCommandText))
                {
                    command.CommandText = newCommandText;
                }
            }

            return base.ReaderExecutingAsync(command, eventData, result);
        }

        private bool IsUsingRealtimeDb(DbContext dbContext) => (dbContext as TreasureHuntDbContext)?.UseRealtimeModel ?? false;
    }

    public static class RealtimeTableNameExtentions
    {
        public static DbContextOptionsBuilder WithRealtimeTableReplacer(
            [System.Diagnostics.CodeAnalysis.NotNull] this Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder,
            Func<string, string> replaceTableFunc)
        {
            var interceptor = new DynamicTableNameIntercepter(replaceTableFunc);
            optionsBuilder.AddInterceptors(interceptor);
            return optionsBuilder;
        }
    }
}

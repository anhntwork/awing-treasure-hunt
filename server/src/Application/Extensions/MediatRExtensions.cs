using Application.Commands.TreasureHuntHandlers;
using Application.Queries.TreasureHuntHandlers;
using Application.Commands.TreasureHunt;
using Domain.Entities;
using Application.Queries.TreasureHunt;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class MediatRExtensions
    {
        public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CalculateFuelCommand, double>, CalculateFuelCommandHandler>();
            
            services.AddTransient<IRequestHandler<GetTreasureHuntHistoryQuery, IEnumerable<TreasureHuntRequestEntity>>, GetTreasureHuntHistoryQueryHandler>();
        }
    }
}

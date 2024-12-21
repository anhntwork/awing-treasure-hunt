using Application.Commands.TreasureHuntHandlers;
using Domain.Commands.TreasureHunt;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class MediatRExtensions
    {
        public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CalculateFuelCommand, double>, CalculateFuelCommandHandler>();
        }
    }
}

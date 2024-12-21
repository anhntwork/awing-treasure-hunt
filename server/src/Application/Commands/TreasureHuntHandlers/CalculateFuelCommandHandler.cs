using Domain;
using Domain.Commands.TreasureHunt;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TreasureHuntHandlers
{
    public class CalculateFuelCommandHandler : IRequestHandler<CalculateFuelCommand, double>
    {
        private readonly ITreasureHuntRepository _treasureHuntRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CalculateFuelCommandHandler(ITreasureHuntRepository treasureHuntRepository, IUnitOfWork unitOfWork)
        {
            _treasureHuntRepository = treasureHuntRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<double> Handle(CalculateFuelCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var treasureHuntRequest = new TreasureHuntRequestEntity
            {
                N = request.N,
                M = request.M,
                P = request.P,
                Matrix = System.Text.Json.JsonSerializer.Serialize(request.Matrix),
            };

            await _treasureHuntRepository.AddAsync(treasureHuntRequest);


            var positions = new Dictionary<int, (int x, int y)>();
            for (int i = 0; i < request.N; i++)
            {
                for (int j = 0; j < request.M; j++)
                {
                    positions[request.Matrix[i][j]] = (i, j);
                }
            }

            double totalFuel = 0;
            for (int i = 1; i < request.P; i++)
            {
                var (x1, y1) = positions[i];
                var (x2, y2) = positions[i + 1];
                totalFuel += Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            }

            treasureHuntRequest.Result = Math.Round(totalFuel, 5);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return treasureHuntRequest.Result;
        }
    }
}


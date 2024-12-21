﻿using Domain.Commands.TreasureHunt;
using MediatR;

namespace Application.Commands.TreasureHuntHandlers
{
    public class CalculateFuelCommandHandler : IRequestHandler<CalculateFuelCommand, double>
    {
        public async Task<double> Handle(CalculateFuelCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

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

            return Math.Round(totalFuel, 5);
        }
    }
}


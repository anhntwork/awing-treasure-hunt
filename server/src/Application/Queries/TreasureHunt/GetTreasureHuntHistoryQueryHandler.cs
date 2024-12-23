using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IRepositories;
using Application.Queries.TreasureHunt;
using MediatR;

namespace Application.Queries.TreasureHuntHandlers
{
    public class GetTreasureHuntHistoryQueryHandler : IRequestHandler<GetTreasureHuntHistoryQuery, IEnumerable<TreasureHuntRequestEntity>>
    {
        private readonly ITreasureHuntRepository _repository;

        public GetTreasureHuntHistoryQueryHandler(ITreasureHuntRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TreasureHuntRequestEntity>> Handle(GetTreasureHuntHistoryQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllAsync();

            return results.OrderByDescending(r => r.CreatedAt);
        }
    }
}

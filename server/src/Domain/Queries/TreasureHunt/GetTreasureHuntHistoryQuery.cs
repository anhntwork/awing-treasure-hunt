using Domain.Entities;
using MediatR;

namespace Domain.Queries.TreasureHunt
{
    public class GetTreasureHuntHistoryQuery : IRequest<IEnumerable<TreasureHuntRequestEntity>>
    {
    }
}

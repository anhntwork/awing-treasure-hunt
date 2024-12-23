using Domain.Entities;
using MediatR;

namespace Application.Queries.TreasureHunt
{
    public class GetTreasureHuntHistoryQuery : IRequest<IEnumerable<TreasureHuntRequestEntity>>
    {
    }
}

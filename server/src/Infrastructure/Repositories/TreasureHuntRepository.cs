using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TreasureHuntRepository : Repository<TreasureHuntRequestEntity, Guid>, ITreasureHuntRepository
    {
        public TreasureHuntRepository(TreasureHuntDbContext context) : base(context)
        {
        }
    }
}

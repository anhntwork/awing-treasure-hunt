using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : Repository<ProductEntity, long>, IProductRepository
    {
        public ProductRepository(TreasureHuntDbContext context) : base(context)
        {
        }
    }

}

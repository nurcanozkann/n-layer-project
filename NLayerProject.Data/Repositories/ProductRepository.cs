using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Entity;
using NLayerProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext appDbContext { get => _context as ApplicationDbContext; }
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}

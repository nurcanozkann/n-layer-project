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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext appDbContext { get => _context as ApplicationDbContext; }
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await appDbContext.Categories.Include(c => c.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}

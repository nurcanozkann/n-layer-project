using NLayerProject.Core.Entity;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}

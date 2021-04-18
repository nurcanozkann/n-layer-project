using NLayerProject.Core.Entity;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}

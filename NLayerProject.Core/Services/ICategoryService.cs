using NLayerProject.Core.Entity;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}

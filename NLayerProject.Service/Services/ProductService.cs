namespace NLayerProject.Service.Services
{
    using NLayerProject.Core.Entity;
    using NLayerProject.Core.Repository;
    using NLayerProject.Core.Services;
    using NLayerProject.Core.UnitOfWorks;
    using System;
    using System.Threading.Tasks;
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository):base(unitOfWork,repository)
        {

        }
        public bool ControlInnerBarcode(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
           return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}

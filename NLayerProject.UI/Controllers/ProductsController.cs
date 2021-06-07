using Microsoft.AspNetCore.Mvc;
using NLayerProject.UI.ApiService;
using NLayerProject.UI.DTOs;
using System.Threading.Tasks;

namespace NLayerProject.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;

        public ProductsController(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productApiService.AddAsync(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productApiService.Update(productDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}

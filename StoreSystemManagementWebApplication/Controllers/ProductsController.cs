using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSystemManagementWebApplication.Data;
using StoreSystemManagementWebApplication.Models;
using StoreSystemManagementWebApplication.Models.Entities;
using StoreSystemManagementWebApplication.Repository;

namespace StoreSystemManagementWebApplication.Controllers
{
    public class ProductsController : Controller
    {
  
        private readonly IProductRepository _productRepository; 
        public ProductsController(IProductRepository productRepository)
        {
            
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModel); 
            }
            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                Category = viewModel.Category,
            };

            await _productRepository.AddProductAsync(product);

            return RedirectToAction("List", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var product = await _productRepository.GetProductByIdAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var product = await _productRepository.GetProductByIdAsync(viewModel.Id);

            if (product is not null)
            {

                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                product.Quantity = viewModel.Quantity;
                product.Category = viewModel.Category;

                //await dbContext.SaveChangesAsync();
                await _productRepository.UpdateProductAsync(product);
            }



            return RedirectToAction("List", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            //var product = await dbContext.Products
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(x => x.Id  == Id);
            //if (product is not null)
            //{

            //    dbContext.Products.Remove(product);
            //    await dbContext.SaveChangesAsync();
            //}
            await _productRepository.DeleteProductAsync(Id);
            return RedirectToAction("List", "Products");
        }
    }
}

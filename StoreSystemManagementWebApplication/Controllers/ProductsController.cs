using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSystemManagementWebApplication.Data;
using StoreSystemManagementWebApplication.Models;
using StoreSystemManagementWebApplication.Models.Entities;

namespace StoreSystemManagementWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await dbContext.Products.ToListAsync();

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
            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                Category = viewModel.Category,
            };
            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product viewModel)
        {

            var product = await dbContext.Products.FindAsync(viewModel.Id);

            if (product is not null)
            {

                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                product.Quantity = viewModel.Quantity;
                product.Category = viewModel.Category;

                await dbContext.SaveChangesAsync();
            }


            return RedirectToAction("List", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var product = await dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id  == Id);
            if (product is not null)
            {

                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StoreSystemManagementWebApplication.Data;
using StoreSystemManagementWebApplication.Models.Entities;

namespace StoreSystemManagementWebApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _dbContext.Products 
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id  == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product); 
            await _dbContext.SaveChangesAsync();
        }
    }
}

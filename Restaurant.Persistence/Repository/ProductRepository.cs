using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infracture.Data;
namespace Restaurant.Infracture.Repository
{
    public class ProductRepository(ApplicationDbContext _context) :IProductRepository
    {
        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var isDelete =await _context.Products.FindAsync(id);
            if (isDelete == null)
                throw new Exception($"ProductId not found {id}");
            _context.Products.Remove(isDelete);
            _context.SaveChangesAsync();
            return isDelete;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetAllProductById(int id)
        {
            return await _context.Products.FindAsync(id);

        }

        public async Task<Product> UpdateProduct( Product product)
        {
            var edit = await _context.Products.FindAsync(product.Id);
            if (edit == null)
                throw new Exception($"ProductId not found {product.Id}");
            edit.Name = product.Name;
            edit.Quantity = product.Quantity;
            edit.Price = product.Price;
            edit.Description = product.Description;
            edit.CategoryId = product.CategoryId;
            await _context.SaveChangesAsync();
            return edit;
        }
    }
}

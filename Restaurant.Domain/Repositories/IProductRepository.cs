using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetAllProductById(int id);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);

        Task<Product> CreateProduct(Product product );
    }
}

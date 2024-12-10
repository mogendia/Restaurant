using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetAllCategoriesById(int id);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int id);

        Task<Category> CreateCategory(Category category);
    }
}

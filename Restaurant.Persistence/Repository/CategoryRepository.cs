using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infracture.Data;

namespace Restaurant.Infracture.Repository
{
    public class CategoryRepository(ApplicationDbContext _context) :ICategoryRepository
    {
        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var isDelete =await _context.Categories.FindAsync(id);
            if (isDelete == null)
                throw new Exception($"CategoryId not found {id}");
            _context.Categories.Remove(isDelete);
            await _context.SaveChangesAsync();
            return isDelete;
        }

        public async Task<List<Category>> GetAllCategories()
        {
           return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetAllCategoriesById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateCategory( Category category)
        {
            var edit = await _context.Categories.FindAsync(category.Id);
            if (edit == null)
                throw new Exception($"CategoryId not found {category.Id}");
            edit.Name = category.Name;
            await _context.SaveChangesAsync();
            return edit;
        }
    }
}

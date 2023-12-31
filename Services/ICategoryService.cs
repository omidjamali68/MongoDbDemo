using MongoDbDemo.Models;

namespace MongoDbDemo.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<string> AddAsync(Category category);
    Task<Category> GetByIdAsync(string id);
    Task UpdateAsync(string id, Category category);
    Task DeleteAsync(string id);
}
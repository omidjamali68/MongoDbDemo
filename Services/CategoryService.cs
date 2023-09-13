using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbDemo.Models;
using MongoDbDemo.Services;

namespace MongoDbDemo;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;

    public CategoryService(IOptions<MongoDbSetting> settings, IMongoClient mongoClient)
    {
        var db = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _categoryCollection = db.GetCollection<Category>(settings.Value.CategoriesCollectionName);
    }
    public async Task<string> AddAsync(Category category)
    {
        await _categoryCollection.InsertOneAsync(category);
        return category.Id;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _categoryCollection.Find(x => true).ToListAsync();
    }
}
using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Models;
using MongoDbDemo.Services;

namespace MongoDbDemo;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<Category>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpPost]
    public async Task<string> Add([FromBody] Category category)
    {
        return await _service.AddAsync(category);
    }
}
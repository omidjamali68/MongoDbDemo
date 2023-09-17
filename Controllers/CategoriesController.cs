using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Models;
using MongoDbDemo.Services;

namespace MongoDbDemo;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult<string>> Add([FromBody] Category category)
    {
        var id = await _service.AddAsync(category);
        return CreatedAtAction(nameof(Add), id);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(string id)
    {
        var category = await _service.GetByIdAsync(id);

        if (category is null)
        {
            return NotFound($"Category with Id = {id} Not found");
        }

        return category;
    }

    [HttpPut("{id}")]
    public async Task Put(string id,[FromBody] Category category)
    {
        await _service.UpdateAsync(id, category);        
    }

    [HttpDelete("{id}")]
    public async Task Delete(string id)
    {
        await _service.DeleteAsync(id);
    }
}
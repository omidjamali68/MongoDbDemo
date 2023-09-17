using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Models;
using MongoDbDemo.Services;

namespace MongoDbDemo;

public static class CategoriesEndpoints
{    
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("minimal-api/categories");
        group.MapPost("", Add);
        group.MapGet("", GetAll);
        group.MapGet("{id}", GetById);
        group.MapPut("{id}", Put);
        group.MapDelete("{id}", Delete);
    }

    [HttpGet]
    public static async Task<List<Category>> GetAll(ICategoryService service)
    {
        return await service.GetAllAsync();
    }

    [HttpPost]
    public static async Task<IResult> Add(
        [FromBody] Category category,
        ICategoryService service)
    {
        var id = await service.AddAsync(category);
        return Results.Ok(id);
    }

    [HttpGet("{id}")]
    public static async Task<IResult> GetById(
        string id,
        ICategoryService service)
    {
        var category = await service.GetByIdAsync(id);

        if (category is null)
        {
            return Results.NotFound($"Category with Id = {id} Not found");
        }

        return Results.Ok(category);
    }

    [HttpPut("{id}")]
    public static async Task Put(
        string id,
        [FromBody] Category category,
        ICategoryService service)
    {
         await service.UpdateAsync(id, category);        
    }

    [HttpDelete("{id}")]
    public static async Task Delete(string id, ICategoryService service)
    {
         await service.DeleteAsync(id);
    }
}
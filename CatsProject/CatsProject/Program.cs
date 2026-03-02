using CatsProject.HostedServices;
using DLL;
using DLL.Models;
using DLL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CatContext>(opt => opt.UseSqlServer());

builder.Services.AddHostedService<RendomCatHostedService>();
builder.Services.AddScoped<CatRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/cats", async (
    CatRepository repository,
    int limit = 10,
    int offset = 0,
    string? name = null) =>
{
    var cats = await repository.GetAll(limit, offset);

    if (!string.IsNullOrEmpty(name))
    {
        cats = cats
            .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    return Results.Ok(cats);
});

app.MapGet("/cats/{id:int}", async (CatRepository repository, int id) =>
{
    var cat = await repository.GetById(id);

    return cat is null
        ? Results.NotFound()
        : Results.Ok(cat);
});

app.MapPost("/cats", async (CatRepository repository, Cat cat) =>
{
    var createdCat = await repository.Add(cat);

    return Results.Created($"/cats/{createdCat.Id}", createdCat);
});

app.MapPut("/cats/{id:int}", async (CatRepository repository, int id, Cat cat) =>
{
    if (id != cat.Id)
        return Results.BadRequest();

    var existingCat = await repository.GetById(id);
    if (existingCat is null)
        return Results.NotFound();

    var updatedCat = await repository.Update(cat);

    return Results.Ok(updatedCat);
});

app.MapDelete("/cats/{id:int}", async (CatRepository repository, int id) =>
{
    var deletedCat = await repository.Delete(id);

    return deletedCat is null
        ? Results.NotFound()
        : Results.Ok(deletedCat);
});

app.UseExceptionHandler(errorApp =>
 {
     errorApp.Run(async context =>
     {
         context.Response.StatusCode = StatusCodes.Status500InternalServerError;
         context.Response.ContentType = "application/json";

         var response = new
         {
             message = "Сталася внутрішня помилка сервера",
         };

         await context.Response.WriteAsJsonAsync(response);
     });
 });


app.Run();

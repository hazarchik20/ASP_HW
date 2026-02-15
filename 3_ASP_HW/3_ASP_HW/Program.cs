using _3_ASP_HW.Filtre;
using _3_ASP_HW.Midleware;
using DLL;
using DLL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=3HWDataBase;Integrated Security=True;"));
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<SubscriptionRepo>();
builder.Services.AddControllers(options =>
{
    _ = options.Filters.Add<LongResponseFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<TimeMiddleware>(); 
app.UseMiddleware<SignatureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

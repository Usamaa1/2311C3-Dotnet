using addToCart.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<CartDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("db")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;
    Console.WriteLine($"Path: {path}");

    // Allow direct access to files or directories
    if (!System.IO.Path.HasExtension(path) && !path.StartsWith("/api"))
    {
        var newPath = path + ".html";
    Console.WriteLine($"newPath: {newPath}");
        context.Request.Path = newPath;
    }

    await next();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDefaultFiles();


app.UseStaticFiles(); 

app.MapControllers();

app.Run();


# 🚀 ASP.NET Core 9 MVC - Product CRUD Application (Complete Guide with Razor Views)

This project demonstrates a **real-world Product Management CRUD** application using:

✅ ASP.NET Core 9 MVC  
✅ Entity Framework Core 9  
✅ Razor Views  
✅ SQL Server  
✅ CSRF Protection  
✅ Asynchronous Programming  

---

## 📦 Project Features

- List all products  
- View product details  
- Create new products  
- Edit existing products  
- Delete products with confirmation  
- Follow best practices for ASP.NET Core 9 MVC  

---

## 🛠 Full Working Code

### 1. Product Model - `Models/Product.cs`

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 2. Database Context - `Data/AppDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Product> Products { get; set; }
}
```

### 3. Program Setup - `Program.cs`

```csharp
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}"
);

app.Run();
```

### 4. appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ProductDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 5. Product Controller - `Controllers/ProductController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index() => View(await _context.Products.ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? NotFound() : View(product);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? NotFound() : View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? NotFound() : View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
```

---

## 🖥 Razor Views

### Index.cshtml

```cshtml
@model IEnumerable<Product>

<h2>Product List</h2>

<p>
    <a asp-action="Create" class="btn btn-primary">Create New</a>
</p>

<table class="table table-bordered">
    <thead>
        <tr>
            <th>Name</th>
            <th>Price</th>
            <th>Actions</th>
        </tr>
    </thead>
    <tbody>
    @foreach (var item in Model)
    {
        <tr>
            <td>@item.Name</td>
            <td>@item.Price.ToString("C")</td>
            <td>
                <a asp-action="Details" asp-route-id="@item.Id" class="btn btn-info btn-sm">Details</a>
                <a asp-action="Edit" asp-route-id="@item.Id" class="btn btn-warning btn-sm">Edit</a>
                <a asp-action="Delete" asp-route-id="@item.Id" class="btn btn-danger btn-sm">Delete</a>
            </td>
        </tr>
    }
    </tbody>
</table>
```

### Create.cshtml

```cshtml
@model Product

<h2>Create Product</h2>

<form asp-action="Create" method="post">
    @Html.AntiForgeryToken()

    <div class="form-group">
        <label asp-for="Name"></label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>

    <div class="form-group">
        <label asp-for="Price"></label>
        <input asp-for="Price" class="form-control" />
        <span asp-validation-for="Price" class="text-danger"></span>
    </div>

    <button type="submit" class="btn btn-primary">Save</button>
    <a asp-action="Index" class="btn btn-secondary">Cancel</a>
</form>
```

### Edit.cshtml

```cshtml
@model Product

<h2>Edit Product</h2>

<form asp-action="Edit" method="post">
    @Html.AntiForgeryToken()
    <input type="hidden" asp-for="Id" />

    <div class="form-group">
        <label asp-for="Name"></label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>

    <div class="form-group">
        <label asp-for="Price"></label>
        <input asp-for="Price" class="form-control" />
        <span asp-validation-for="Price" class="text-danger"></span>
    </div>

    <button type="submit" class="btn btn-primary">Update</button>
    <a asp-action="Index" class="btn btn-secondary">Cancel</a>
</form>
```

### Details.cshtml

```cshtml
@model Product

<h2>Product Details</h2>

<div>
    <strong>Name:</strong> @Model.Name
</div>
<div>
    <strong>Price:</strong> @Model.Price.ToString("C")
</div>

<p>
    <a asp-action="Edit" asp-route-id="@Model.Id" class="btn btn-warning">Edit</a>
    <a asp-action="Index" class="btn btn-secondary">Back to List</a>
</p>
```

### Delete.cshtml

```cshtml
@model Product

<h2>Confirm Delete</h2>

<div>
    <strong>Name:</strong> @Model.Name
</div>
<div>
    <strong>Price:</strong> @Model.Price.ToString("C")
</div>

<form asp-action="Delete" method="post">
    @Html.AntiForgeryToken()
    <input type="hidden" asp-for="Id" />

    <p>Are you sure you want to delete this product?</p>

    <button type="submit" class="btn btn-danger">Delete</button>
    <a asp-action="Index" class="btn btn-secondary">Cancel</a>
</form>
```

---

## 📚 Key Technical Concepts Explained

- **`[ValidateAntiForgeryToken]`**: Protects forms from CSRF attacks by requiring a secure token.  
- **`Task<IActionResult>`**: Enables asynchronous controller actions for better performance.  
- **`[HttpPost, ActionName("Delete")]`**: Allows both GET and POST Delete actions without method name conflicts.  

---

## ⚙️ Setup Instructions

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

Visit `https://localhost:5001` to access the application.

---

## 🎉 Conclusion

This project offers a clean, production-style ASP.NET Core 9 MVC CRUD application with Razor Views and best practices for building robust web applications.


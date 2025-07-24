using addToCart.Data;
using addToCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace addToCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CartDbContext _context;
        private readonly IWebHostEnvironment _enviornment;
        private readonly IConfiguration _config;

        public ProductController(CartDbContext context, IWebHostEnvironment enviornment, IConfiguration config)
        {
            _context = context;
            _enviornment = enviornment;
            _config = config;
        }



        [HttpPost("category")]
        public IActionResult addCategory(Category category)
        {


            try
            {
                if (category != null) { 
                
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok("Category Added");
                
                }
                return StatusCode(204);
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            
            }


        }



        [HttpPost]
        public async Task<IActionResult> addProduct(ProductCreate product)
        {
            try
            {

                if (product != null) {

                    if (product.ProdImage != null) {

                        var uploadPath = _config["StoredFilesPath"];

                        if (!Directory.Exists(uploadPath))
                            Directory.CreateDirectory(uploadPath);


                        var extension = Path.GetExtension(product.ProdImage.FileName);
                        var imageName = Guid.NewGuid().ToString() + extension;
                                        //7jfkdj47-dfs33kfds-fkjs + .jpg
                        var filePath = Path.Combine(uploadPath, imageName); //  wwwroot/upload/7jfkdj47-dfs33kfds-fkjs.jpg

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await product.ProdImage.CopyToAsync(stream);
                        }


                        var prod = new Product
                        {
                            ProdName = product.ProdName,
                            ProdPrice = product.ProdPrice,
                            ProdDesc = product.ProdDesc,
                            ProdImage = imageName,
                            CategoryId = product.CategoryId,
                        };


                        _context.Products.Add(prod);
                        _context.SaveChanges();
                        return Ok("Product Added Successfully!");






                    }
                
                
                }

            




                return StatusCode(204);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("catProd")]
        public IActionResult getProductsWithCategory()
        {
            var data = _context.Products.
                Include(item => item.Category).
                Select(item => new ProductDTO
                {
                    Id = item.Id,
                    ProdName = item.ProdName,
                    ProdDesc = item.ProdDesc,
                    ProdImage = item.ProdImage,
                    ProdPrice = item.ProdPrice,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category.CategoryName
                }

                ).ToList();
            
            
            
            return Ok(data);
        }









    }
}

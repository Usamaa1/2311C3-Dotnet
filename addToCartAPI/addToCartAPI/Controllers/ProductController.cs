using addToCartAPI.Data;
using addToCartAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addToCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CartDbContext _context;

        public ProductController(CartDbContext context)
        {
            _context = context;
        }

        [HttpPost("category")]

        public IActionResult addCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok("category added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]

        public IActionResult addProduct(Product product)
        {

            //return Ok(product);
            try
            {
                var category = _context.Categories.Find(product.CategoryId);
                if (category != null)
                {
                    product.Category = category;
                }
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }


        }




    }
}

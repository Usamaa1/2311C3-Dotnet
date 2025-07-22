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

        public ProductController(CartDbContext context)
        {
            _context = context;
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
        public IActionResult addProduct(Product product)
        {
            try
            {

                if(product != null)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return Ok("Product Added");
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

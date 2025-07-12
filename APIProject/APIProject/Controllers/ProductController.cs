using APIProject.Data;
using APIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Db2311C3Context _context;

        public ProductController(Db2311C3Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        public IActionResult addProducts(Product product)
        {
            try {
                _context.Products.Add(product);
                _context.SaveChanges();

                return Ok("Product Added Successfully");
                //return StatusCode(201);

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }



      
        }

        [HttpDelete]
        public IActionResult deleteProducts(int delId)
        {
            try
            {
              var prod =  _context.Products.Find(delId);
                _context.Products.Remove(prod);
                _context.SaveChanges();
                return Ok("Product Deleted Successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult updateProducts(int upId, Product product)
        {

            try
            {

              var prod = _context.Products.Find(upId);

                prod.ProdName = product.ProdName;
                prod.ProdPrice = product.ProdPrice;
                prod.ProdDesc = product.ProdDesc;

                _context.Products.Update(prod);
                _context.SaveChanges();
                return Ok("Product Updated Successfully");


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                return StatusCode(500);
            }
        }
   
    
    
    }
}

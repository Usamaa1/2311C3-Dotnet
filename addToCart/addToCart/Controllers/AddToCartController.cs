using addToCart.Data;
using addToCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addToCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToCartController : ControllerBase
    {

        private readonly CartDbContext _context;

        public AddToCartController(CartDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCart(CartDto dto)
        {
            try
            {

                var existing = _context.Carts
                    .FirstOrDefault(c => c.UserId == dto.UserId && c.ProductId == dto.ProductId);

                if (existing != null)
                {
                    existing.Quantity += dto.Quantity;
                }
                else
                {
                    _context.Carts.Add(new Cart
                    {
                        UserId = dto.UserId,
                        ProductId = dto.ProductId,
                        Quantity = dto.Quantity
                    });
                }

                _context.SaveChanges();
                return Ok("Product added to cart");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

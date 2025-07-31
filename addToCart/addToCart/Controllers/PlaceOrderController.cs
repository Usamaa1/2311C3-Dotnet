using addToCart.Data;
using addToCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addToCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOrderController : ControllerBase
    {

        private readonly CartDbContext _context;
        public PlaceOrderController(CartDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PlaceOrder(int userId)
        {
            try
            {
                var cartItems = _context.Carts.Where(c => c.UserId == userId).ToList();

                if (!cartItems.Any())
                    return BadRequest("Cart is empty.");

                var order = new Order { UserId = userId };
                _context.Orders.Add(order);
                _context.SaveChanges(); // Get OrderId

                foreach (var item in cartItems)
                {
                    _context.OrderItems.Add(new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                }

                // Clear cart after placing order
                _context.Carts.RemoveRange(cartItems);
                _context.SaveChanges();

                return Ok("Order placed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

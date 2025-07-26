namespace addToCart.Models
{
    public class CartDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }


    }
}

namespace addToCart.Models
{
    public class ProductCreate
    {
        public int Id { get; set; }

        public string ProdName { get; set; } = null!;

        public string ProdPrice { get; set; } = null!;

        public string? ProdDesc { get; set; }


        public int CategoryId { get; set; }

        
        public IFormFile? ProdImage { get; set; }
    }
}

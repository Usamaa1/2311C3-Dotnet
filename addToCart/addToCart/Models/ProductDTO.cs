using System.Text.Json.Serialization;

namespace addToCart.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string ProdName { get; set; } = null!;

        public string ProdPrice { get; set; } = null!;

        public string? ProdDesc { get; set; }

        public string? ProdImage { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }


    }
}

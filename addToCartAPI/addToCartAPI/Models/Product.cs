using System;
using System.Collections.Generic;

namespace addToCartAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProdName { get; set; } = null!;

    public string ProdDesc { get; set; } = null!;

    public string ProdPrice { get; set; } = null!;

    public string? ProdImage { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}

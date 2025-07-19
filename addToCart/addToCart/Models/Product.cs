using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace addToCart.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProdName { get; set; } = null!;

    public string ProdPrice { get; set; } = null!;

    public string? ProdDesc { get; set; }

    public string? ProdImage { get; set; }

    public int CategoryId { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
}

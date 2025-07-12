using System;
using System.Collections.Generic;

namespace APIProject.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProdName { get; set; } = null!;

    public string ProdDesc { get; set; } = null!;

    public decimal ProdPrice { get; set; }
}

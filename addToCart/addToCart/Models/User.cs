using System;
using System.Collections.Generic;

namespace addToCart.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}

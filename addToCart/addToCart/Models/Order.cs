using System;
using System.Collections.Generic;

namespace addToCart.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

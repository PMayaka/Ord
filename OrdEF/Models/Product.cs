using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string ProductCrtdId { get; set; } = null!;

    public DateTime ProductCrtdDt { get; set; }

    public string ProductUpdtId { get; set; } = null!;

    public DateTime ProductUpdtDt { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();
}

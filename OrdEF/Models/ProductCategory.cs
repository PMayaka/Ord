using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class ProductCategory
{
    public string ProductCategoryId { get; set; } = null!;

    public string ProductCategoryProductId { get; set; } = null!;

    public string ProductCategoryCategoryId { get; set; } = null!;

    public DateTime? ProductCategoryEffDate { get; set; }

    public string ProductCategoryCrtdId { get; set; } = null!;

    public DateTime ProductCategoryCrtdDt { get; set; }

    public string ProductCategoryUpdtId { get; set; } = null!;

    public DateTime ProductCategoryUpdtDt { get; set; }

    public virtual Category ProductCategoryCategory { get; set; } = null!;

    public virtual Product ProductCategoryProduct { get; set; } = null!;
}

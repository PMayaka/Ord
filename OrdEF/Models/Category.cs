using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string? CategoryPrntCategoryId { get; set; }

    public string? CategoryCategoryTypeId { get; set; }

    public string CategoryCrtdId { get; set; } = null!;

    public DateTime CategoryCrtdDt { get; set; }

    public string CategoryUpdtId { get; set; } = null!;

    public DateTime CategoryUpdtDt { get; set; }

    public virtual CategoryType? CategoryCategoryType { get; set; }

    public virtual Category? CategoryPrntCategory { get; set; }

    public virtual ICollection<Category> InverseCategoryPrntCategory { get; set; } = new List<Category>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}

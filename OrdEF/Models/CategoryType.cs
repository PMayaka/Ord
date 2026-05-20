using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class CategoryType
{
    public string CategoryTypeId { get; set; } = null!;

    public string? CategoryTypeDesc { get; set; }

    public string CategoryTypeCrtdId { get; set; } = null!;

    public DateTime CategoryTypeCrtdDt { get; set; }

    public string CategoryTypeUpdtId { get; set; } = null!;

    public DateTime CategoryTypeUpdtDt { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}

using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class VwProductPrice
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string ProductPriceId { get; set; } = null!;

    public decimal? ProductPricePrice { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}

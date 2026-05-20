using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class VwProductMaxPriceIncrease
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string ProductPriceId { get; set; } = null!;

    public decimal? PctIncrease { get; set; }
}

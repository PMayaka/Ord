using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class OrderLine
{
    public string OrderLineId { get; set; } = null!;

    public string OrderLineOrderId { get; set; } = null!;

    public string OrderLineProductId { get; set; } = null!;

    public short? OrderLineQty { get; set; }

    public decimal? OrderLineUnitPrice { get; set; }

    public string OrderLineCrtdId { get; set; } = null!;

    public DateTime OrderLineCrtdDt { get; set; }

    public string OrderLineUpdtId { get; set; } = null!;

    public DateTime OrderLineUpdtDt { get; set; }

    public virtual Order OrderLineOrder { get; set; } = null!;

    public virtual Product OrderLineProduct { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class Order
{
    public string OrdersId { get; set; } = null!;

    public string OrdersCustomerId { get; set; } = null!;

    public DateTime? OrdersDate { get; set; }

    public string? OrdersOrderStatusId { get; set; }

    public string? OrdersCustomerAddressId { get; set; }

    public string OrdersCrtdId { get; set; } = null!;

    public DateTime OrdersCrtdDt { get; set; }

    public string OrdersUpdtId { get; set; } = null!;

    public DateTime OrdersUpdtDt { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual Customer OrdersCustomer { get; set; } = null!;

    public virtual CustomerAddress? OrdersCustomerAddress { get; set; }

    public virtual OrderStatus? OrdersOrderStatus { get; set; }
}

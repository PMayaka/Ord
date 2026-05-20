using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class CustomerAddress
{
    public string CustomerAddressId { get; set; } = null!;

    public string CustomerAddressCustomerId { get; set; } = null!;

    public string CustomerAddressAddressId { get; set; } = null!;

    public bool? CustomerAddressDflt { get; set; }

    public bool? CustomerAddressActvInd { get; set; }

    public string CustomerAddressCrtdId { get; set; } = null!;

    public DateTime CustomerAddressCrtdDt { get; set; }

    public string CustomerAddressUpdtId { get; set; } = null!;

    public DateTime CustomerAddressUpdtDt { get; set; }

    public virtual Address CustomerAddressAddress { get; set; } = null!;

    public virtual Customer CustomerAddressCustomer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

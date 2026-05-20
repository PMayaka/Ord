using System;
using System.Collections.Generic;

namespace Ord.EF.Models;

public partial class Address
{
    public string AddressId { get; set; } = null!;

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? AddressZipcode { get; set; }

    public string AddressCrtdId { get; set; } = null!;

    public DateTime AddressCrtdDt { get; set; }

    public string AddressUpdtId { get; set; } = null!;

    public DateTime AddressUpdtDt { get; set; }

    public virtual Zip? AddressZipcodeNavigation { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
}

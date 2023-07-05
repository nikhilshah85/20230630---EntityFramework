using System;
using System.Collections.Generic;

namespace shoppingAPP.Models.EF;

public partial class CustomersList
{
    public int CId { get; set; }

    public string? CName { get; set; }

    public string? CCity { get; set; }

    public int? CWalletBalance { get; set; }

    public bool? CIsActive { get; set; }
}

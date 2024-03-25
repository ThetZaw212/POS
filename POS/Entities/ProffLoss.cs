using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Entities;

[Keyless]
[Table("Proff_Loss")]
public partial class ProffLoss
{
    [StringLength(256)]
    public string? StoreName { get; set; }

    public int? OnHandQty { get; set; }

    [Column("purchaseTotal")]
    public double? PurchaseTotal { get; set; }

    public double? SlaeTotal { get; set; }

    [Column("profit_Loss")]
    public double? ProfitLoss { get; set; }
}

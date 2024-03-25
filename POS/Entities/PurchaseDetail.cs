using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Entities;

[PrimaryKey("PurchaseId", "ItemId")]
[Table("PurchaseDetail")]
public partial class PurchaseDetail
{
    [Key]
    [Column("PurchaseID")]
    [StringLength(50)]
    public string PurchaseId { get; set; } = null!;

    [Key]
    [Column("ItemID")]
    [StringLength(50)]
    public string ItemId { get; set; } = null!;

    public int? PurchaseQty { get; set; }

    public double? PurchasePrice { get; set; }
}

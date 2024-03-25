using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Entities;

[PrimaryKey("SlaeId", "ItemId")]
[Table("SlaeDetail")]
public partial class SlaeDetail
{
    [Key]
    [Column("SlaeID")]
    [StringLength(50)]
    public string SlaeId { get; set; } = null!;

    [Key]
    [Column("ItemID")]
    [StringLength(50)]
    public string ItemId { get; set; } = null!;

    public int? SlaeQty { get; set; }

    public double? SalePrice { get; set; }
}

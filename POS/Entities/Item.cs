using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Entities;

[Table("Item")]
public partial class Item
{
    [Key]
    [Column("ItemID")]
    [StringLength(50)]
    public string ItemId { get; set; } = null!;

    [StringLength(256)]
    public string? ItemName { get; set; }

    public int? ItemQty { get; set; }

    public double? ItemPrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatDate { get; set; }
}

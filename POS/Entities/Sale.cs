using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Entities;

[Table("Sale")]
public partial class Sale
{
    [Key]
    [Column("SaleID")]
    [StringLength(50)]
    public string SaleId { get; set; } = null!;

    [StringLength(50)]
    public string? Voucher { get; set; }

    public double? TotalAmount { get; set; }

    public double? Tax { get; set; }

    public double? GrandTotal { get; set; }
}

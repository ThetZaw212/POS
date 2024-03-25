using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Entities;

[Table("Purchase")]
public partial class Purchase
{
    [Key]
    [Column("PurchaseID")]
    [StringLength(50)]
    public string PurchaseId { get; set; } = null!;

    public DateOnly? PurchaseDate { get; set; }

    [Column("SupplierID")]
    [StringLength(50)]
    public string? SupplierId { get; set; }

    public double? TotalAmount { get; set; }
}

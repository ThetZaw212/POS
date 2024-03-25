using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Entities;

[Table("Shop")]
public partial class Shop
{
    [Key]
    [Column("ShopID")]
    [StringLength(50)]
    public string ShopId { get; set; } = null!;

    [StringLength(256)]
    public string? ShopName { get; set; }

    public DateOnly? JoinDate { get; set; }

    public string? DetailAddress { get; set; }

    public TimeOnly? OpenHour { get; set; }

    public TimeOnly? CloseHour { get; set; }
}

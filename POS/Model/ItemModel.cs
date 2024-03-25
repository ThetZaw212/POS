using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS.Model
{
    public class ItemModel
    {

        
        public string ItemId { get; set; } = null!;

        
        public string? ItemName { get; set; }

        public int? ItemQty { get; set; }

        public double? ItemPrice { get; set; }

        
        public DateTime? CreatedDate { get; set; }

        
        public DateTime? UpdatDate { get; set; }
    }
}

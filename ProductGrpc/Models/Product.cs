using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductGrpc.Models
{
    public class Product
    {
        [Column("ProductID")]
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

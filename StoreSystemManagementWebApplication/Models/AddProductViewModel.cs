using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSystemManagementWebApplication.Models
{
    public class AddProductViewModel
    {

        public required string Name { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Category { get; set; }
    }
}

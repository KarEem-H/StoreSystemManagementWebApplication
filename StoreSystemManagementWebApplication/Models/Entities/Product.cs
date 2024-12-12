namespace StoreSystemManagementWebApplication.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public  string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Category { get; set; }

    }
}

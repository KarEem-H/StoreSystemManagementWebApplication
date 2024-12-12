namespace StoreSystemManagementWebApplication.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        
        [Required]
        public  string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
       
        [Required] 
        public string? Category { get; set; }

    }
}

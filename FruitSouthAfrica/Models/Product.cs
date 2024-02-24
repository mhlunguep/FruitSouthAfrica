using System.ComponentModel.DataAnnotations;

namespace FruitSouthAfrica.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please provide a Product Code")]
        public string ProductCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please provide a Product Name")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please provide a Category Name")]
        public string CategoryName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please provide a Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        // IFormFile property for file upload
        public IFormFile? ImageFile { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}

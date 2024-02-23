namespace FruitSouthAfrica.Models
{

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}

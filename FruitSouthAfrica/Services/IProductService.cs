using FruitSouthAfrica.Models;

namespace FruitSouthAfrica.Services
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task UpdateProductAsync(Product product);
    }
}
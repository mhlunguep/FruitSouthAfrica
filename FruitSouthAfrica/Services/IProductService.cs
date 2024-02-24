using FruitSouthAfrica.Models;

namespace FruitSouthAfrica.Services
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task UpdateProductAsync(Product product);
    }
}
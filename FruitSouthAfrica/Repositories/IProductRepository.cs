using FruitSouthAfrica.Models;

namespace FruitSouthAfrica.Repositories
{
    public interface IProductRepository
    {
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task SaveProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}
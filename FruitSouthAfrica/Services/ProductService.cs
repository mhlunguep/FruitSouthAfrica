using FruitSouthAfrica.Models;
using FruitSouthAfrica.Repositories;

namespace FruitSouthAfrica.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw;
            }
        }

        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                // Perform any validation or business logic here if needed
                return await _productRepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw;
            }
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            try
            {
                // Perform any validation or business logic here if needed
                return await _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw;
            }
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            try
            {
                // Check if the product exists or perform any other validation if needed
                return await _productRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw;
            }
        }
    }
}

using FruitSouthAfrica.Models;
using FruitSouthAfrica.Repositories;
using System;

namespace FruitSouthAfrica.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving products: {ex.Message}");
                throw; // Re-throw the exception for the caller to handle
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            try
            {
                // Retrieve the product by its ID
                return await _productRepository.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving the product: {ex.Message}");
                throw; // Re-throw the exception for the caller to handle
            }
        }

        public async Task AddProductAsync(Product product)
        {
            try
            {
                // Add your business logic here, if needed
                await _productRepository.SaveProductAsync(product);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
                throw; // Re-throw the exception for the caller to handle
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                // Add your business logic here, if needed
                await _productRepository.UpdateProductAsync(product);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
                throw; // Re-throw the exception for the caller to handle
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                // Add your business logic here, if needed
                await _productRepository.DeleteProductAsync(productId);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
                throw; // Re-throw the exception for the caller to handle
            }
        }
    }
}

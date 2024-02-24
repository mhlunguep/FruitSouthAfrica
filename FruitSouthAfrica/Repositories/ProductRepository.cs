using FruitSouthAfrica.Models;

namespace FruitSouthAfrica.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository _db;

        public ProductRepository(IRepository db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // Call the LoadData method with appropriate parameters
            return await _db.LoadData<Product, dynamic>("dbo.GetProducts", new { });
        }

        public async Task SaveProductAsync(Product product)
        {
            await _db.SaveData("dbo.InsertProduct", product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _db.UpdateData("dbo.UpdateProduct", product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _db.DeleteData("dbo.DeleteProduct", new { ProductId = productId });
        }
    }
}

using Product.API.Models;

namespace Product.API.Repositories.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetProductById(int productId);
        ProductModel CreateProduct(ProductModel product);
        bool UpdateProduct(ProductModel product);
        bool DeleteProduct(int productId);
    }
}

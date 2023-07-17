using ProductAPIEFCore.Model;

namespace ProductAPIEFCore.Repository
{
    public interface IProdRepo<Product>
    {
        int add(int a, int b);

        bool check(int a);
       List<Product> GetAllProducts();
        void AddNewProduct(Product p);
        Product DeleteProduct(int  id);
        Task<Product> GetProductById(int id);
        Task UpdateProduct(int id,Product p);

    }
}

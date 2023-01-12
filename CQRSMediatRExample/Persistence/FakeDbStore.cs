using System.Net.Http.Headers;
using CQRSMediatRExample.Models;

namespace CQRSMediatRExample.Persistence
{
    public class FakeDbStore
    {

        public static List<Product> products = new List<Product>()
        {
                new Product {Id = 1, Name = "Product1"},
                new Product {Id = 2, Name = "Product2"},
                new Product {Id = 3, Name = "Product3"},
        };


        public async Task<Product> AddProduct(Product product)
        {
            var addedProduct = new Product { Id = product.Id, Name = product.Name };
            products.Add(addedProduct);
            return await Task.FromResult(addedProduct);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.FromResult(products);
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = products.First(p => p.Id == id);
            return await Task.FromResult(product);
        }

        public async Task EventOccurred(Product product, string evt)
        {
            products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }

    }
}

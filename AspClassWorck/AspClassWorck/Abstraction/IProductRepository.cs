using AspClassWorck.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AspClassWorck.Abstraction
{
    public interface IProductRepository
    {
        public int AddProduct(ProductDTO product);
        public IEnumerable<ProductDTO> GetProducts();
        public string GetProductsFileCsv();
        public string GetCacheStatsUrl();
        public int UpdateProduct(ProductDTO product);
        public int DeleteProduct(ProductDTO product);
    }
}

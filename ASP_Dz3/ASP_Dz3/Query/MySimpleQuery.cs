using ASP_Dz3.Abstractions;
using ASP_Dz3.Models;
using ASP_Dz3.Models.Dto;

namespace ASP_Dz3.Query
{
    public class MySimpleQuery
    {
        public IEnumerable<ProductDto> GetProducts([Service] IProductService service) => service.GetProducts();
        public IEnumerable<StorageDto> GetStorages([Service] IStorageService service) => service.GetStorages();
        public IEnumerable<CategoryDto> GetCategories([Service] ICategoryService service) => service.GetCategories();
        public IEnumerable<ProductDto> GetProductsInStorage(int id,[Service] IProductsInStorageService service) => service.GetProductsInStorage(id);
    }
}

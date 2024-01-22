using ASP_Dz3.Models.Dto;

namespace ASP_Dz3.Abstractions
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto product);
    }
}

using ASP_Dz3.Models.Dto;
using ASP_Dz3.Models;
using HotChocolate.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ASP_Dz3.Abstractions
{
    public interface IProductsInStorageService
    {
        public int AddProductInWarehouse(ProductDto product, StorageDto storage);
        public IEnumerable<ProductDto> GetProductsInStorage(int Id);
    }
}
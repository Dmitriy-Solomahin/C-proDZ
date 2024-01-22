using ASP_Dz3.Abstractions;
using ASP_Dz3.Models;
using ASP_Dz3.Models.Dto;

namespace ASP_Dz3.Mutatin
{
    public class MySimpleMutation
    {
        public int AddProduct(ProductDto product, [Service] IProductService service) { return service.AddProduct(product);}

        public int AddStorage(StorageDto storage, [Service] IStorageService service) { return service.AddStorage(storage); }

        public int AddProductInWarehouse(ProductDto product, StorageDto storage, [Service] IProductsInStorageService service)
        {return service.AddProductInWarehouse(product, storage);}

    }
}

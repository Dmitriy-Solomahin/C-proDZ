using ASP_Dz3.Models.Dto;
using ASP_Dz3.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using ASP_Dz3.Abstractions;

namespace ASP_Dz3.Services
{
    public class ProductsInStorageService : IProductsInStorageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProductsInStorageService(AppDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddProductInWarehouse(ProductDto product, StorageDto storage)
        {
            using (_context)
            {
                var entityProduct = _context.Products.FirstOrDefault(x => x.Name.ToLower().Equals(product.Name.ToLower()));
                var entityStorage = _context.Storages.FirstOrDefault(x => x.Name.ToLower().Equals(storage.Name.ToLower()));
                if (entityProduct is not null && entityStorage is not null) {
                    entityProduct.Storage = entityStorage;
                    entityStorage.Products.Add(entityProduct);
                    _context.Storages.Update(entityStorage);
                    _context.Products.Update(entityProduct);
                    _context.SaveChanges();
                    _cache.Remove("storages");
                    _cache.Remove("products");
                }

                return entityProduct.Id;
            }
        }

        public IEnumerable<ProductDto> GetProductsInStorage(int Id)
        {
            using (_context)
            {

                var storage = _context.Storages.FirstOrDefault(x => x.Id == Id);
                if (storage is not null)
                {
                    var products = storage.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                    return products;
                }

                return new List<ProductDto>();
            }
        }
    }
}

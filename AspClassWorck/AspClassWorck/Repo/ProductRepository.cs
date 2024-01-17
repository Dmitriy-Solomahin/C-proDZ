using AspClassWorck.Abstraction;
using AspClassWorck.Models;
using AspClassWorck.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace AspClassWorck.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductRepository(IMapper mapper, IMemoryCache memoryCache, ProductContext context)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _context = context;
        }
        public int AddProduct(ProductDTO product)
        {
            using (_context)
            {
                var entityProduct = _context.Products.FirstOrDefault(x => x.Name.ToLower().Equals(product.Name.ToLower()));
                if (entityProduct == null)
                {
                    entityProduct = _mapper.Map<Product>(product);
                    _context.Products.Add(entityProduct);
                    _context.SaveChanges();
                    _memoryCache.Remove("products");
                }
                return entityProduct.Id;
            }
        }

        public int DeleteProduct(ProductDTO product)
        {
            using (_context)
            {
                var entityProduct = _context.Products.FirstOrDefault(x => x.Name.ToLower().Equals(product.Name.ToLower()));
                if (entityProduct != null)
                {
                    entityProduct = _mapper.Map<Product>(entityProduct);
                    _context.Products.Remove(entityProduct);
                    _context.SaveChanges();
                    _memoryCache.Remove("products");
                }
                return entityProduct.Id;
            } 
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            if (_memoryCache.TryGetValue("products", out List<ProductDTO> products))
                return products;
            using (_context)
            {
                var productsList = _context.Products.Select(x => _mapper.Map<ProductDTO>(x)).ToList();
                _memoryCache.Set("products", productsList, TimeSpan.FromMinutes(30));
                return productsList;
            }
        }

        public string GetProductsFileCsv()
        {
            var content = "";
            if (_memoryCache.TryGetValue("products", out List<ProductDTO> products))
                content = GetCsv(products);
            using (_context)
            {
                var productsList = _context.Products.Select(x => _mapper.Map<ProductDTO>(x)).ToList();
                _memoryCache.Set("products", productsList, TimeSpan.FromMinutes(30));
                content = GetCsv(productsList);
            }
            return content;
        }

        public string GetCacheStatsUrl()
        {
            string fileName = "CacheFile" + DateTime.Now.ToBinary() + ".csv";
            System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "CacheFiles", fileName), GetStatsToString());
            return fileName;
        }

        public int UpdateProduct(ProductDTO product)
        {
            using (_context)
            {
                var entityProduct = _context.Products.FirstOrDefault(x => x.Name.ToLower().Equals(product.Name.ToLower()));
                if (entityProduct != null)
                {
                    entityProduct = _mapper.Map<Product>(entityProduct);
                    entityProduct.Price = product.Price;
                    _context.Products.Update(entityProduct);
                    _context.SaveChanges();
                    _memoryCache.Remove("products");
                }
                return entityProduct.Id;
            }
        }

        private string GetStatsToString()
        {
            var statistics = _memoryCache.GetCurrentStatistics();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("totalHits: " + statistics.TotalHits.ToString());
            sb.AppendLine("TotalMisses: " + statistics.TotalMisses.ToString());
            sb.AppendLine("CurrentEntryCount: " + statistics.CurrentEntryCount.ToString());
            sb.AppendLine("CurrentEstimatedSize: " + statistics.CurrentEstimatedSize.ToString());
            return sb.ToString();
        }

        private string GetCsv(IEnumerable<ProductDTO> products)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine(product.Id + ";" + product.Name+ ";"+ product.Descript + "\n");
            }
            return sb.ToString();
        }
    }
}

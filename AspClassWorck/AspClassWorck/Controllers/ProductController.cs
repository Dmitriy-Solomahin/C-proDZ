using AspClassWorck.Abstraction;
using AspClassWorck.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AspClassWorck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("get_product")]
        public IActionResult GetProduct()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("get_products_file_csv")]
        public FileContentResult GetProductFile()
        {
            var result = _productRepository.GetProductsFileCsv();
            return File(new UTF8Encoding().GetBytes(result), "text/csv", "products.csv"); ;
        }

        [HttpPost("add_product")]
        public IActionResult AddProduct([FromBody] ProductDTO productDTO) 
        {
            var result = _productRepository.AddProduct(productDTO);
            return Ok(result);
        }

        [HttpDelete("delete_product")]
        public IActionResult DeleteProduct([FromBody] ProductDTO productDTO)
        {
            var result = _productRepository.DeleteProduct(productDTO);
            return Ok(result);
        }

        [HttpPatch("update_product_price")]
        public IActionResult UpdateProductPrice([FromBody] ProductDTO productDTO)
        {
            var result = _productRepository.UpdateProduct(productDTO);
            return Ok(result);
        }

        [HttpGet("get_cache_file_url")]
        public ActionResult<string> GetCacheFileUrl()
        {
            var fileName = _productRepository.GetCacheStatsUrl();
            return "https://" + Request.Host.ToString() + "/static/" + fileName;
        }
    }
}

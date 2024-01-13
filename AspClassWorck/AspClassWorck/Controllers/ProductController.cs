using AspClassWorck.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspClassWorck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet("getProduct")]
        public IActionResult GetProduct()
        {
            try
            {
                using (var context = new ProductContext())
                {
                    var products = context.Products.Select(x => new Product()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Descript = x.Descript,
                    });
                    return Ok(products);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost("putProduct")]
        public IActionResult PutProduct([FromQuery] string name, string descript, int groupId, int price) 
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if(!context.Products.Any(x => x.Name.ToLower().Equals(name))){
                        context.Add(new Product()
                        {
                            Name = name,
                            Descript = descript,
                            GroupId = groupId,
                            Price = price
                        });
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpDelete("deleteProduct")]
        public IActionResult DeleteProduct([FromQuery] int productId)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    var product = context.Products.FirstOrDefault(x => x.Id == productId);
                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPatch("updateProductPrice")]
        public IActionResult UpdateProductPrice([FromQuery] int productId, int price)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    var product = context.Products.FirstOrDefault(x => x.Id == productId);
                    if (product != null)
                    {
                        product.Price = price;
                        context.Products.Update(product);
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

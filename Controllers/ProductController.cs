using BasicProduct.DTOs.Responses;
using BasicProduct.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BasicProduct.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private static List<ProductResponseDto> _products = new List<ProductResponseDto>();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponseDto>> GetAllProducts()
        {
            _logger.LogInformation("ProductController: Getting all products");

            if (_products == null || !_products.Any())
            {
                _logger.LogInformation("ProductController: No products found");
                return NoContent();
            }
            return Ok(_products);
        }

        // GET: api/Products/{guid}
        [HttpGet("{guid}")]
        public ActionResult<ProductResponseDto> GetProduct(Guid guid)
        {
            _logger.LogInformation($"ProductController: Getting product with guid {guid}");
            var product = _products.FirstOrDefault(p => p.Guid == guid);

            if (product == null)
            {
                _logger.LogWarning($"ProductController: Product with GUID {guid} not found");
                return NotFound($"Product with GUID {guid} not found");
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<ProductResponseDto> CreateProduct(ProductCreateRequestDto product)
        {
            if (product == null)
            {
                _logger.LogWarning("ProductController: Received null product in CreateProduct");
                return BadRequest("Product data is required.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ProductController: Invalid product data received in CreateProduct");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("ProductController: Creating new product");
                var createdProduct = new ProductResponseDto
                {
                    Guid = Guid.NewGuid(), // Simulate the database generating a new GUID
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                };

                _products.Add(createdProduct);

                // Return a 201 Created response with the location of the new resource
                return CreatedAtAction(nameof(GetProduct), new { guid = createdProduct.Guid }, createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductController: Error occurred while creating product");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Products/{guid}
        [HttpPut("{guid}")]
        public ActionResult<ProductResponseDto> UpdateProduct(Guid guid, ProductUpdateRequestDto product)
        {
            if (product == null)
            {
                _logger.LogWarning("ProductController: Received null product in UpdateProduct");
                return BadRequest("Product data is required.");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ProductController: Invalid product data received in UpdateProduct");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation($"ProductController: Updating product with guid {guid}");
                var existingProduct = _products.FirstOrDefault(p => p.Guid == guid);

                if (existingProduct == null)
                {
                    _logger.LogWarning($"ProductController: Product with GUID {guid} not found");
                    return NotFound($"Product with GUID {guid} not found");
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;

                return Ok(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductController: Error occurred while updating product");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Products/{guid}
        [HttpDelete("{guid}")]
        public ActionResult DeleteProduct(Guid guid)
        {
            _logger.LogInformation($"ProductController: Deleting product with guid {guid}");

            try
            {
                var product = _products.FirstOrDefault(p => p.Guid == guid);

                if (product == null)
                {
                    _logger.LogWarning($"ProductController: Product with GUID {guid} not found");
                    return NotFound($"Product with GUID {guid} not found");
                }

                _products.Remove(product);

                _logger.LogInformation($"ProductController: Product with GUID {guid} deleted successfully");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductController: Error occurred while deleting product");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
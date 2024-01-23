using log4net;
using Microsoft.AspNetCore.Mvc;
using WPeCommerceAPI.BusinessLogic.Services;

namespace WPeCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private static ILog _logger = LogManager.GetLogger(typeof(ProductController));

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var products = _service.GetAll();
            if(products != null)
            {
                _logger.Info("Successfully retrieve products");
            }
            return Ok(products);
        }
    }
}

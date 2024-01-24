using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using WPeCommerceAPI.BusinessLogic.Services;
using WPeCommerceAPI.DataLayer.DTO;

namespace WPeCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private static ILog _logger = LogManager.GetLogger(typeof(ProductController));
        private static IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var products = _service.GetAll();
            if(products != null)
            {
                _logger.Info("Successfully retrieve products");
            }
            var productsDto = products.Select(x => _mapper.Map<ProductDTO>(x));
            return Ok(productsDto);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            var productDto = _mapper.Map<ProductDTO>(product);
            return Ok(productDto);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WPeCommerceAPI.BusinessLogic.Services;
using WPeCommerceAPI.DataLayer.DTO;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        private readonly IMapper _mapper;
        public ReviewController(IReviewService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("GetByProduct/{productId}")]
        public IActionResult GetByProductId(int productId)
        {
            var reviews = _service.GetByProductId(productId);
            return Ok(reviews);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var review = _service.GetById(id);
            return Ok(review);
        }

        [HttpPost("AddReview")]
        public IActionResult Create([FromBody] ReviewDTO reviewDto)
        {
            if(reviewDto == null)
            {
                return BadRequest(ModelState);
            }
            var existingReview = GetByProductId(reviewDto.Id);
            if(existingReview != null)
            {
                ModelState.AddModelError("", "Review Already Exist");
                return StatusCode(402, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = _mapper.Map<Review>(reviewDto);
            if (_service.Create(review))
            {
                return CreatedAtAction(nameof(GetById), new { id = reviewDto.Id }, reviewDto);
            }
            else
            {
                return StatusCode(500, "Failed to add new review");
            }

        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Story.Application.Abstract;
using Story.Data.Dto.Rating;

namespace Story.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly ILogger<RatingsController> _logger;
        private readonly IRatingService _ratingService;

        public RatingsController(ILogger<RatingsController> logger, IRatingService ratingService)
        {
            _logger = logger;
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(short id)
        {
            var result = await _ratingService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ratingService.GetRatings();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CreateRatingDto createRatingDto)
        {
            var result = await _ratingService.AddRating(createRatingDto);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UpdateRatingDto updateRatingDto)
        {
            if (updateRatingDto == null)
                return BadRequest("UpdateRatingDto cannot be null.");

            var result = await _ratingService.UpdateRating(updateRatingDto);
            if (result == null)
                return NotFound("Rating not found.");

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var result = await _ratingService.DeleteRating(id);
            if (result == null)
                return NotFound("Rating not found.");

            return Ok(result);
        }
    }
}
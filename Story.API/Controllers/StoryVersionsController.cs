using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Story.Application.Abstract;
using Story.Data.Dto.StoryVersion;

namespace Story.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryVersionsController : ControllerBase
    {
        private readonly ILogger<StoryVersionsController> _logger;
        private readonly IStoryVersionService _storyVersionService;

        public StoryVersionsController(ILogger<StoryVersionsController> logger, IStoryVersionService storyVersionService)
        {
            _logger = logger;
            _storyVersionService = storyVersionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(short id)
        {
            var result = await _storyVersionService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _storyVersionService.GetStoryVersions();
            return Ok(result);
        }

        [HttpPost("add")]
        [RequestSizeLimit(10_000_000)] // 10 MB örnek

        public async Task<IActionResult> AddAsync([FromBody] CreateStoryVersionDto createStoryVersionDto)
        {
            var result = await _storyVersionService.AddStoryVersion(createStoryVersionDto);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UpdateStoryVersionDto updateStoryVersionDto)
        {
            if (updateStoryVersionDto == null)
                return BadRequest("UpdateStoryVersionDto cannot be null.");

            var result = await _storyVersionService.UpdateStoryVersion(updateStoryVersionDto);
            if (result == null)
                return NotFound("StoryVersion not found.");

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var result = await _storyVersionService.DeleteStoryVersion(id);
            if (result == null)
                return NotFound("StoryVersion not found.");

            return Ok(result);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Story.Application.Abstract;
using Story.Data.Dto.Story;

namespace Story.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly ILogger<StoriesController> _logger;
        private readonly IStoryService _storyService;

        public StoriesController(ILogger<StoriesController> logger, IStoryService storyService)
        {
            _logger = logger;
            _storyService = storyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(short id)
        {
            var result = await _storyService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _storyService.GetStories();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CreateStoryDto createStoryDto)
        {
            var result = await _storyService.AddStory(createStoryDto);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UpdateStoryDto updateStoryDto)
        {
            if (updateStoryDto == null)
                return BadRequest("UpdateStoryDto cannot be null.");

            var result = await _storyService.UpdateStory(updateStoryDto);
            if (result == null)
                return NotFound("Story not found.");

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var result = await _storyService.DeleteStory(id);
            if (result == null)
                return NotFound("Story not found.");

            return Ok(result);
        }
    }
}
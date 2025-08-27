using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Story.Application.Abstract;
using Story.Data.Dto.Chapter;

namespace Story.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly ILogger<ChaptersController> _logger;
        private readonly IChapterService _chapterService;

        public ChaptersController(ILogger<ChaptersController> logger, IChapterService chapterService)
        {
            _logger = logger;
            _chapterService = chapterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(short id)
        {
            var result = await _chapterService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _chapterService.GetChapters();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CreateChapterDto createChapterDto)
        {
            var result = await _chapterService.AddChapter(createChapterDto);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UpdateChapterDto updateChapterDto)
        {
            if (updateChapterDto == null)
                return BadRequest("UpdateChapterDto cannot be null.");

            var result = await _chapterService.UpdateChapter(updateChapterDto);
            if (result == null)
                return NotFound("Chapter not found.");

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var result = await _chapterService.DeleteChapter(id);
            if (result == null)
                return NotFound("Chapter not found.");

            return Ok(result);
        }
    }
}
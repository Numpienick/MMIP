using MMIP.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : Controller
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService) => _tagService = tagService;

        [HttpGet("value")]
        public IActionResult GetTagsByValue(string value)
        {
            return Ok(_tagService.GetTags(value));
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            return Ok(await _tagService.GetByIdAsync(id));
        }
    }
}

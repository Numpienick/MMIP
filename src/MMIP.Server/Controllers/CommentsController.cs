using Microsoft.AspNetCore.Mvc;
using MMIP.Infrastructure.Services;
using MMIP.Shared.Entities;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MMIP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            try
            {
                await _commentService.AddAsync(comment);
                return Ok("Successfully created comment");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetComment(Guid id)
        {
            var result = await _commentService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("view")]
        public async Task<IActionResult> GetCommentsView(Guid id)
        {
            var view = await _commentService.GetCommentViewAsync(id);
            if (view != null)
                return Ok(view);

            return NotFound("Comments not found");
        }
    }
}

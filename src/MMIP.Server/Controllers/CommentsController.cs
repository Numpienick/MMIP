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

        // TODO: Get comments from specific challenge.
        [HttpGet("byChallengeId")]
        public async Task<IActionResult> GetCommentsByChallengeId(Guid challengeId)
        {
            var result = await _commentService.GetCommentsByChallengeIdAsync(challengeId);
            if (result.Any())
                return Ok(result);
            return Empty;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using Infrastructure.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private readonly CommentService _commentService;
        private readonly ChallengeService _challengeService;

        public CommentsController(CommentService commentService, ChallengeService challengeService)
        {
            _commentService = commentService;
            _challengeService = challengeService;
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            try
            {
                _commentService.CreateComment(comment);
                return Ok("Successfully created comment");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(Guid id)
        {
            return Ok(_commentService.GetComment(id));
        }

        // TODO: Get comments from specific challenge.
        [HttpGet]
        public IActionResult GetComments(Guid challengeId)
        {
            //Challenge challenge = _challengeService.GetChallenge(challengeId);
            //return Ok(_commentService.GetComments().Where(r => r.Id == challengeId));
            return Ok(_commentService.GetComments());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MMIP.Infrastructure.Services;

namespace MMIP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly OrganizationService _organizationService;

        public OrganizationsController(OrganizationService organizationService) =>
            _organizationService = organizationService;

        [HttpGet("challenges")]
        public async Task<IActionResult> GetChallenges(Guid id, int take, int skip)
        {
            var result = await _organizationService.GetChallenges(id);
            if (result.Any())
                return Ok(result);

            return Empty;
        }

        [HttpGet("carousel")]
        public async Task<IActionResult> GetCarousel(int take)
        {
            var result = await _organizationService.GetCarouselAsync(take);
            return Ok(result);
        }
    }
}

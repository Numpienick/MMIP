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

        [HttpGet("challenges/overview")]
        public async Task<IActionResult> GetChallengesOverview(Guid id, int take, int skip)
        {
            var result = await _organizationService.GetChallengesOverviewAsync(id, take, skip);
            return Ok(result);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile(Guid id)
        {
            var result = await _organizationService.GetProfileAsync(id);
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("carousel")]
        public async Task<IActionResult> GetCarousel(int take)
        {
            var result = await _organizationService.GetCarouselAsync(take);
            return Ok(result);
        }
    }
}

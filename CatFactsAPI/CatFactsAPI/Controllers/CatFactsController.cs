using CatFactsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CatFactsAPI.Controllers
{
    [ApiController]
    [Route("cat/facts")]
    public class CatFactsController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ICatFactsService catFactsService;
        public CatFactsController(IConfiguration configuration, ICatFactsService catFactsService)
        {
            this.configuration = configuration;
            this.catFactsService = catFactsService;
        }

        [HttpGet(Name = "GetCatFacts")]
        public async Task<IActionResult> Get()
        {
            var publicAPIUrl = configuration["PublicAPI:BaseUrl"];
            var catFacts = await catFactsService.GetCatFacts($"{publicAPIUrl}/facts");
            if (catFacts.Count() == 0) return NotFound();

            return Ok(catFacts);
        }
    }
}
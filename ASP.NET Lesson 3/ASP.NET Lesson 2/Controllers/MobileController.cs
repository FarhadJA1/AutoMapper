using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lesson_2.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MobileController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public MobileController(IMobileService mobileService)
        {
            _mobileService = mobileService;
        }

        [HttpPost]
        public async Task<IActionResult> Sell(int id,int count)
        {
            var result = await _mobileService.SellAsync(id, count);

            if(result==null)
                return NotFound();

            if (result.Keys.First() == false)
            {
                return BadRequest($"Count:{result.Values.First()}");
            }
            return Ok(result.Values.First());
        }
    }
}

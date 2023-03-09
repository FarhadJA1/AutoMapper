using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lesson_2.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string model, string color, int price)
        {
            var car = await _carService.Create(model, color, price);
            return Ok(car);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _carService.Delete(id);
            if (result==false)
            {
                return NotFound("Car not found");
            }
            return Ok("Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carService.GetAll();

            if (result == null)
                return NotFound("No cars found");

            return Ok(result);            
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _carService.GetById(id);
            if (result == null)
                return NotFound("Not found");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string model, string color, int price)
        {
            var result =  await _carService.Update(id,model,color,price);
            if (result == false)
                return NotFound("Not found");

            return Ok("Updated");
        }

    }
}

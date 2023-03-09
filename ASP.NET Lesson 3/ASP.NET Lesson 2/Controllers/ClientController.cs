using ASP.NET_Lesson_2.Dtos.ClientDtos;
using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lesson_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateDto clientCreateDto)
        {
            var car = await _clientService.CreateAsync(clientCreateDto);
            return Ok(car);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clientService.DeleteAsync(id);
            if (result == false)
            {
                return NotFound("Client not found");
            }
            return Ok("Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clientService.GetAllAsync();

            if (result == null)
                return NotFound("No clients found");

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id,bool withComputer)
        {
            var result = await _clientService.GetByIdAsync(id, withComputer);
            if (result == null)
                return NotFound("Not found");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string name, string surname,int computerId)
        {
            var result = await _clientService.UpdateAsync(id, name, surname, computerId);
            if (result == null)
                return NotFound("Not found");

            return Ok(result);
        }
    }
}

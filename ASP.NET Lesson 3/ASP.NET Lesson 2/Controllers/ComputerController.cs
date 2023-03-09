using ASP.NET_Lesson_2.Services.Implementations;
using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lesson_2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComputerController : ControllerBase
{
    private readonly IComputerService _computerService;

    public ComputerController(IComputerService computerService)
    {
        _computerService = computerService;
    }
    [HttpPost]
    public async Task<IActionResult> Create(string model, string compCode)
    {
        var car = await _computerService.Create(model, compCode);
        return Ok(car);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _computerService.Delete(id);
        if (result == false)
        {
            return NotFound("Computer not found");
        }
        return Ok("Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _computerService.GetAll();

        if (result == null)
            return NotFound("No computers found");

        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _computerService.GetById(id);
        if (result == null)
            return NotFound("Not found");
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, string model, string compCode)
    {
        var result = await _computerService.Update(id, model, compCode);
        if (result == null)
            return NotFound("Not found");

        return Ok(result);
    }
}

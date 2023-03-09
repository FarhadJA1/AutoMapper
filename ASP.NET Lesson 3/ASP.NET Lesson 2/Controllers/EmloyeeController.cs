using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Implementations;
using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lesson_2.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly DIInterface _dIInterface;

    public EmployeeController(IEmployeeService employeeService, DIInterface dIInterface)
    {
        _employeeService = employeeService;
        _dIInterface = dIInterface;
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<Employee> employees = _employeeService.GetAllEmployees();

        if (employees.Count==0)
            return NotFound("Employee not found!!!");

        return Ok(employees);
    }

    [HttpPost]   
    public IActionResult Create(Employee employee)
    {
        _employeeService.CreateEmployee(employee);      
        return Ok(employee);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        string result = _employeeService.DeleteEmployee(id);

        if (result == "404")
            return NotFound("Employee not found");

        return Ok(result);
    }

    [HttpGet("Id")]
    public IActionResult GetById(int id)
    {
        Employee employee = _employeeService.GetById(id);

        if (employee==null)
            return NotFound("Employee not found!!!");

        return Ok(employee);
    }

    [HttpPut]
    public IActionResult Update(int id,Employee entity)
    {
        bool result = _employeeService.UpdateEmployee(id,entity);
        if (result == false)
            return NotFound("Employee not found!!!");
        return Ok("updated");
    }

    [HttpGet("guid")]
    public IActionResult ReturnGuid()
    {
        return Ok(_dIInterface.ReturnGuid());
    }
    [HttpGet("guid2")]
    public IActionResult ReturnGuid2()
    {
        return Ok(_dIInterface.ReturnGuid());
    }
}

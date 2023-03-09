using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Lesson_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(string groupCode)
        {
            var classroom = await _classroomService.CreateAsync(groupCode);
            return Ok(classroom);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _classroomService.DeleteAsync(id);
            if (result == false)
            {
                return NotFound("Classroom not found");
            }
            return Ok("Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _classroomService.GetAllAsync();

            if (result == null)
                return NotFound("No classrooms found");

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _classroomService.GetByIdAsync(id);
            if (result == null)
                return NotFound("Not found");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string groupCode)
        {
            var result = await _classroomService.UpdateAsync(id,groupCode);
            if (result == null)
                return NotFound("Not found");

            return Ok(result);
        }
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher(int classroomId,int teacherId)
        {
            var result = await _classroomService.AddTeacherAsync(classroomId, teacherId);

            if (result == false)
                return BadRequest("Something went wrong!!!");
            return Ok("Successfully added!!!");
        }
    }
}

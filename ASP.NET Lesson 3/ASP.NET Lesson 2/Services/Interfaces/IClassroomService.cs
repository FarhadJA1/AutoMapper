using ASP.NET_Lesson_2.Dtos.ClassroomDtos;
using ASP.NET_Lesson_2.Models;

namespace ASP.NET_Lesson_2.Services.Interfaces;
public interface IClassroomService
{
    Task<List<Classroom>> GetAllAsync();
    Task<Classroom> CreateAsync(string groupCode);
    Task<bool> DeleteAsync(int id);
    Task<Classroom> UpdateAsync(int id, string groupCode);
    Task<Classroom> GetByIdAsync(int id);
    Task<bool> AddTeacherAsync(int classroomId, int teacherId);
}

using ASP.NET_Lesson_2.Models;

namespace ASP.NET_Lesson_2.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> Create(string name, string surname);
    }
}

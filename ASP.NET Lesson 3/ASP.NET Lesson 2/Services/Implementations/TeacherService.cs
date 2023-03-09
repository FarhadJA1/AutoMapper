using ASP.NET_Lesson_2.Data;
using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Interfaces;

namespace ASP.NET_Lesson_2.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _context;

        public TeacherService(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<Teacher> Create(string name, string surname)
        {
            Teacher teacher = new()
            {
                Name= name,
                Surname = surname
            };
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}

using ASP.NET_Lesson_2.Data;
using ASP.NET_Lesson_2.Dtos.ClassroomDtos;
using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Lesson_2.Services.Implementations;
public class ClassroomService : IClassroomService
{
    private readonly AppDbContext _context;

    public ClassroomService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddTeacherAsync(int classroomId,int teacherId)
    {
        var classroom = await _context.Classrooms.FirstOrDefaultAsync(m=>m.Id==classroomId);
        var teacher = await _context.Teachers.FirstOrDefaultAsync(m=>m.Id== teacherId);

        if(classroom != null && teacher != null)
        {
            ClassroomTeacher classroomTeacher = new()
            {
                ClassroomId = classroomId,
                TeacherId = teacherId
            };
            await _context.ClassroomTeachers.AddAsync(classroomTeacher);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Classroom> CreateAsync(string groupCode)
    {
        Classroom classroom = new()
        {
            GroupCode = groupCode,
        };
        await _context.Classrooms.AddAsync(classroom);
        await _context.SaveChangesAsync();
        return classroom;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var classroom = await _context.Classrooms.FirstOrDefaultAsync(x => x.Id == id);
        if (classroom == null)
            return false;
        _context.Classrooms.Remove(classroom);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Classroom>> GetAllAsync()
    {
         var classrooms = await _context.Classrooms
                        .Include(m=>m.Clients).ThenInclude(x=>x.Computer)
                        .Include(m=>m.ClassroomTeachers).ThenInclude(m=>m.Teacher)
                        .ToListAsync();
        return classrooms;
    }

    public async Task<Classroom> GetByIdAsync(int id)
    {
        var classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.Id == id);
        if (classroom == null)
            return null;

        return classroom;
    }

    public async Task<Classroom> UpdateAsync(int id, string groupCode)
    {
        var classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.Id == id);
        if (classroom == null)
            return null;

        classroom.GroupCode = groupCode;
        
        await _context.SaveChangesAsync();
        return classroom;
    }
}

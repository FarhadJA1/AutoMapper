using ASP.NET_Lesson_2.Models;

namespace ASP.NET_Lesson_2.Dtos.ClassroomDtos
{
    public class ClassroomDto
    {
        public string GroupCode { get; set; } = string.Empty;

        public List<ClassroomTeacher> ClassroomTeachers { get; set; }
        public List<ClassroomClientDto> Clients { get; set; }
    }
    public class ClassroomClientDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public ClassroomClientComputerDto Computer { get; set; }
    }
    public class ClassroomClientComputerDto
    {
        public string Model { get; set; } = string.Empty;
        public string CompCode { get; set; } = string.Empty;
    }
}


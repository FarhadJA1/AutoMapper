namespace ASP.NET_Lesson_2.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;


        public List<ClassroomTeacher> ClassroomTeachers { get; set; }
    }
}

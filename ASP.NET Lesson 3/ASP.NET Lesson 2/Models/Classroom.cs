namespace ASP.NET_Lesson_2.Models;
public class Classroom
{
    public int Id { get; set; }
    public string GroupCode { get; set; } = string.Empty;



    public List<ClassroomTeacher> ClassroomTeachers { get; set; }
    public List<Client> Clients { get; set; }
}

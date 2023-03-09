namespace ASP.NET_Lesson_2.Models;
public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int ComputerId { get; set; }
    public int? ClassroomId { get; set; }


    public Computer Computer { get; set; }
}

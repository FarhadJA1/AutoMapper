namespace ASP.NET_Lesson_2.Models;
public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int Price { get; set; }
    public DateTime CreatedDate { get; set; }
}

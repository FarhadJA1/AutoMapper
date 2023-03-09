namespace ASP.NET_Lesson_2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Salary { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}

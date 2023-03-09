using ASP.NET_Lesson_2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Lesson_2.Data;
public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<Student> Students { get; set; }
	public DbSet<Car> Cars { get; set; }
	public DbSet<Mobile> Mobiles { get; set; }
	public DbSet<Client> Clients { get; set; }
	public DbSet<Computer> Computers { get; set; }
	public DbSet<Classroom> Classrooms { get; set; }
	public DbSet<ClassroomTeacher> ClassroomTeachers { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

}

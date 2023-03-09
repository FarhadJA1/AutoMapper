using ASP.NET_Lesson_2.Models;

namespace ASP.NET_Lesson_2.Services.Interfaces;
public interface IEmployeeService
{
    public List<Employee> GetAllEmployees();
    public Employee GetById(int id);
    public void CreateEmployee(Employee employee);
    public string DeleteEmployee(int id);
    public bool UpdateEmployee(int id, Employee entity);
}

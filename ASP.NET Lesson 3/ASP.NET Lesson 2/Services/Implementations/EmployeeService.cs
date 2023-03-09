using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Interfaces;

namespace ASP.NET_Lesson_2.Services.Implementations;
public class EmployeeService : IEmployeeService
{
    private static List<Employee> _employees = new List<Employee>();
    public void CreateEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public string DeleteEmployee(int id)
    {
        Employee? employee = _employees.FirstOrDefault(m => m.Id == id);
        
        if(employee != null)
        {
            employee.IsDeleted = true;
            return $"{employee.Name} {employee.Surname} is deleted";
        }
        return "404";
    }

    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = _employees.Where(m => m.IsDeleted == false).ToList();

        return employees;
    }

    public Employee GetById(int id)
    {
        Employee? employee = _employees.FirstOrDefault(m => m.Id == id);

        if(employee == null)
            return null;

        return employee;
    }

    public bool UpdateEmployee(int id,Employee entity)
    {
        Employee? employee = _employees.Where(m => m.Id == id && m.IsDeleted == false).FirstOrDefault();

        if (employee == null)
               return false;

        _employees.Remove(employee);
        employee.Name = entity.Name;
        employee.Surname = entity.Surname;
        employee.Address = entity.Address;
        employee.Profession = entity.Profession;
        employee.Salary = entity.Salary;
        _employees.Add(employee);
        return true;
    }
}

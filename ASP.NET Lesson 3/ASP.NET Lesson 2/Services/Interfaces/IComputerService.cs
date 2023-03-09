using ASP.NET_Lesson_2.Models;

namespace ASP.NET_Lesson_2.Services.Interfaces
{
    public interface IComputerService
    {
        Task<List<Computer>> GetAll();
        Task<Computer> Create(string model, string compCode);
        Task<bool> Delete(int id);
        Task<Computer> Update(int id, string model, string compCode);
        Task<Computer> GetById(int id);
    }
}

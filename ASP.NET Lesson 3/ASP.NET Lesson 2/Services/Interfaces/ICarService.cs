using ASP.NET_Lesson_2.Models;

namespace ASP.NET_Lesson_2.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<Car>> GetAll();
        Task<Car> Create(string model, string color, int price);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, string model, string color, int price);
        Task<Car> GetById(int id);
    }
}

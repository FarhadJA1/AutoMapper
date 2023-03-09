using ASP.NET_Lesson_2.Data;
using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Lesson_2.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(string model, string color, int price)
        {
            Car car = new()
            {
                Model= model,
                Color=color,
                Price=price,
                CreatedDate = DateTime.Now,
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<bool> Delete(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return false;
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Car>> GetAll()
        {
            List<Car> cars = await _context.Cars.OrderByDescending(m=>m.CreatedDate).ToListAsync();

            if (cars.Count==0)
            {
                return null;
            }

            return cars;
        }

        public async Task<Car> GetById(int id)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
                return null;
            return car;
        }

        public async Task<bool> Update(int id, string model, string color, int price)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return false;
            }
            car.Model = model;
            car.Price = price;
            car.Color = color;
            car.CreatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;

        }
    }
}

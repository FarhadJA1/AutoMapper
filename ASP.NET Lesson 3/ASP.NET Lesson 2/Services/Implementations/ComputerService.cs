using ASP.NET_Lesson_2.Data;
using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Lesson_2.Services.Implementations;
public class ComputerService : IComputerService
{
    private readonly AppDbContext _context;

    public ComputerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Computer> Create(string model, string compCode)
    {
        Computer computer = new()
        {
            Model = model,
            CompCode = compCode
        };
        await _context.Computers.AddAsync(computer);
        await _context.SaveChangesAsync();
        return computer;
    }

    public async Task<bool> Delete(int id)
    {
        var computer = await _context.Computers.FirstOrDefaultAsync(x=>x.Id== id);
        if (computer == null)
            return false;
        _context.Computers.Remove(computer);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Computer>> GetAll()
    {
        return await _context.Computers.ToListAsync();
    }

    public async Task<Computer> GetById(int id)
    {
        var computer = await _context.Computers.FirstOrDefaultAsync(m=>m.Id== id);
        if (computer == null)
                return null;

        return computer;
    }

    public async Task<Computer> Update(int id, string model, string compCode)
    {
        var computer = await _context.Computers.FirstOrDefaultAsync(m => m.Id == id);
        if (computer == null)
                return null;

        computer.Model= model;
        computer.CompCode= compCode;
        await _context.SaveChangesAsync();
        return computer;
    }
}

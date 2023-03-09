using ASP.NET_Lesson_2.Data;
using ASP.NET_Lesson_2.Dtos.ClientDtos;
using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ASP.NET_Lesson_2.Services.Implementations;
public class ClientService : IClientService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public ClientService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ClientCreateDto> CreateAsync(ClientCreateDto clientCreateDto)
    {
        await _context.Clients.AddAsync(_mapper.Map<Client>(clientCreateDto));
        await _context.SaveChangesAsync();
        return clientCreateDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        if (client == null)
            return false;
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await _context.Clients.Include(m=>m.Computer).ToListAsync();
    }

    public async Task<ClientDto> GetByIdAsync(int id,bool withComputer)
    {
        switch (withComputer)
        {
            case true:
                var clientWithComputer = await _context.Clients.Include(m => m.Computer).FirstOrDefaultAsync(x=>x.Id==id);
                if (clientWithComputer == null)
                    return null;
                return _mapper.Map<ClientDto>(clientWithComputer);
                   
            case false:
                var client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
                if (client == null)
                    return null;                
                return _mapper.Map<ClientDto>(client);
            default:
                break;
        }

      

        
       
    }

    public async Task<Client> UpdateAsync(int id, string name, string surname, int computerId)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
        if (client == null)
            return null;

        client.Name = name;
        client.Surname = surname;
        client.ComputerId = computerId;
        await _context.SaveChangesAsync();
        return client;
    }
}

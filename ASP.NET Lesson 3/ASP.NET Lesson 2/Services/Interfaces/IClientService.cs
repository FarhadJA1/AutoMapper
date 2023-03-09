using ASP.NET_Lesson_2.Dtos.ClientDtos;
using ASP.NET_Lesson_2.Models;

namespace ASP.NET_Lesson_2.Services.Interfaces;
public interface IClientService
{
    Task<List<Client>> GetAllAsync();
    Task<ClientCreateDto> CreateAsync(ClientCreateDto clientCreateDto);
    Task<bool> DeleteAsync(int id);
    Task<Client> UpdateAsync(int id, string name, string surname, int computerId);
    Task<ClientDto> GetByIdAsync(int id, bool withComputer = false);
}

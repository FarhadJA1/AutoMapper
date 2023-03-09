namespace ASP.NET_Lesson_2.Services.Interfaces
{
    public interface IMobileService
    {
        Task<Dictionary<bool, int>> SellAsync(int id,int count);
    }
}

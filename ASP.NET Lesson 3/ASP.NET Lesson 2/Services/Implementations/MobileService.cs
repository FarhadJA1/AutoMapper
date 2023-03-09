using ASP.NET_Lesson_2.Data;
using ASP.NET_Lesson_2.Models;
using ASP.NET_Lesson_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Lesson_2.Services.Implementations
{
    public class MobileService : IMobileService
    {
        private readonly AppDbContext _context;

        public MobileService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<bool, int>> SellAsync(int id, int count)
        {
            Mobile? mobile = await _context.Mobiles.FirstOrDefaultAsync(m => m.Id == id);
            Dictionary<bool,int> result = new Dictionary<bool, int>();

            if (mobile == null)
                return null;
            if (mobile.Count - count >= 0)
            {
                mobile.Count -= count;
                await _context.SaveChangesAsync();
                result.Add(true, mobile.Count);
            }
            result.Add(false, mobile.Count);
            return result;
        }
    }
}

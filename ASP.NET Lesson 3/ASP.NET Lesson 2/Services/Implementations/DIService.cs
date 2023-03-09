using ASP.NET_Lesson_2.Services.Interfaces;

namespace ASP.NET_Lesson_2.Services.Implementations
{
    public class DIService : DIInterface
    {
        public string ReturnGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

namespace ASP.NET_Lesson_2.Dtos.ClientDtos
{
    public class ClientDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public ClientsComputerDto Computer { get; set; }
    }


    public class ClientsComputerDto
    {
        public string Model { get; set; } = string.Empty;
        public string CompCode { get; set; } = string.Empty;
    }
}

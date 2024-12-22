using System.Net.Sockets;

namespace WebfejlesztesAPI.Services.Dto
{
    public class CharterDto
    {
        public long Id { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}

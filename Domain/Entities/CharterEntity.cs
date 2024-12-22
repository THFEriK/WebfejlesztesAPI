namespace Domain.Entities
{
    public class CharterEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}

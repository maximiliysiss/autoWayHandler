namespace ProjectTransportSystem.Models.Database
{
    public class Trip
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Distance { get; set; }
    }
}
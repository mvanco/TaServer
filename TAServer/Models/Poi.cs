namespace TAServer.Models
{
    public class POI
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Type { get; set; }
    }
}
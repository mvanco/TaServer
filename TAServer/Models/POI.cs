namespace TAServer.Models
{
    public class POI
    {
        public long id { get; set; }
        public string title { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int type { get; set; }
    }
}
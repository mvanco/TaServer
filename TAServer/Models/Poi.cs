namespace TaServer.Models
{
    public class Poi
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Type { get; set; }

        public Poi() { }

        public Poi(Poi poi)
        {
            this.Id = poi.Id;
            this.Title = poi.Title;
            this.Latitude = poi.Latitude;
            this.Longitude = poi.Longitude;
            this.Type = poi.Type;
        }
    }

}
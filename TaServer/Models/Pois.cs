using System.Collections.Generic;

namespace TaServer.Models
{
    public class Pois
    {
        public List<Poi> PoiList { get; }

        public Pois(Poi[] Pois)
        {
            this.PoiList = new List<Poi>(Pois);
        }
    }
}
using System.Collections.Generic;

namespace TAServer.Models
{
    public class PoisApi
    {
        public List<POI> Pois;

        public PoisApi(POI[] POIs)
        {
            this.Pois = new List<POI>(POIs);
        }
    }
}
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using sfx.Data;
using TaServer.Models;

namespace TaServer.Controllers
{
    [Produces("application/json")]
    public class TrainAlertController : Controller
    {
        private static int LocationIterator = 1; // TODO: remove this (SimulatedRepository)
        private static bool ToTheLeftDirection = true; // TODO: remove this (SimulatedRepository)
        private readonly TrainAlertDbContext Context;

        private JsonSerializer serializer = new JsonSerializer
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public TrainAlertController(TrainAlertDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetLocation()
        {
            var res = new JObject();
            res["errorCode"] = 0;

            var location =
                Context.Locations.FirstOrDefault(location1 =>
                    location1.Id == LocationIterator); // TODO: remove this (SimulatedRepository)
                                                       //            var location = _context.Location.OrderByDescending(l => l.id).FirstOrDefault(); // TODO: uncomment this

            if (ToTheLeftDirection)
            {
                if (LocationIterator < 232)
                {
                    LocationIterator++;
                }
                else
                {
                    ToTheLeftDirection = false;
                    LocationIterator--;
                }
            }
            else
            {
                if (LocationIterator > 1)
                {
                    LocationIterator--;
                }
                else
                {
                    ToTheLeftDirection = true;
                    LocationIterator++;
                }
            }

            res["data"] = JToken.FromObject(location, serializer);
            return Content(res.ToString(), "application/json");
        }

        [HttpGet]
        public IActionResult GetPois()
        {
            var res = new JObject();
            res["errorCode"] = 0;
            res["data"] = JToken.FromObject(new Pois(Context.Pois.OrderBy(t => t.Id).ToArray()), serializer);
            return Content(res.ToString(), "application/json");
        }

        [HttpPost]
        public IActionResult AddPoi([FromBody] Poi poi)
        {
            var res = new JObject();
            res["errorCode"] = 0;

            foreach (Poi p in Context.Pois) {
                if (p.Title.Equals(poi.Title))
                {
                    return null;
                }
            }

            Context.Pois.Add(poi);
            Context.SaveChanges();

            res["data"] = JToken.FromObject(poi, serializer);
            return Content(res.ToString(), "application/json");
        }

        [HttpPut]
        public IActionResult EditPoi(long id, [FromBody] Poi poi)
        {
            var res = new JObject();
            res["errorCode"] = 0;

            var newPoi = Context.Pois.FirstOrDefault(t => t.Id == id);
            if (newPoi == null)
            {
                return null;
            }

            newPoi.Title = poi.Title;
            newPoi.Latitude = poi.Latitude;
            newPoi.Longitude = poi.Longitude;
            newPoi.Type = poi.Type;
            Context.Pois.Update(newPoi);
            Context.SaveChanges();

            res["data"] = JToken.FromObject(newPoi, serializer);
            return Content(res.ToString(), "application/json");
        }

        [HttpGet]
        public IActionResult DeletePoi(long id)
        {
            var res = new JObject();
            res["errorCode"] = 0;

            var poiToRemove = Context.Pois.FirstOrDefault(t => t.Id == id);

            if (poiToRemove != null)
            {
                Context.Pois.Remove(poiToRemove);
                Context.SaveChanges();

                res["data"] = JToken.FromObject(poiToRemove, serializer);
                return Content(res.ToString(), "application/json");
            }
            else
            {
                res["errorCode"] = -1;
                return Content(res.ToString(), "application/json");
            }
 
        }
    }
}
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public TrainAlertController(TrainAlertDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetLocation()
        {
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

            return Json(location);
        }

        [HttpGet]
        public IActionResult GetPois()
        {
            return Json(new Pois(Context.Pois.ToArray()));
        }

        [HttpPost]
        public IActionResult AddPoi([FromBody] Poi poi)
        {
            foreach (Poi p in Context.Pois) {
                if (p.Title.Equals(poi.Title))
                {
                    return null;
                }
            }

            Context.Pois.Add(poi);
            Context.SaveChanges();
            return Json(poi);
        }

        [HttpPut]
        public IActionResult EditPoi(long id, [FromBody] Poi poi)
        {
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
            return Json(newPoi);
        }
    }
}
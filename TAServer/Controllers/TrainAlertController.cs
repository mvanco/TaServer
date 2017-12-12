﻿using System.Linq;
 using Microsoft.AspNetCore.Mvc;
 using sfx.Data;

namespace TAServer.Controllers
{
    [Produces("application/json")]
    public class TrainAlertController : Controller
    {
        private static int LocationIterator = 1; // TODO: remove this (SimulatedRepository)
        private static bool ToTheLeftDirection = true; // TODO: remove this (SimulatedRepository)
        private readonly TrainAlertDBContext Context;

        public TrainAlertController(TrainAlertDBContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetLocation() {
            
            var location = Context.Locations.FirstOrDefault(location1 => location1.Id == LocationIterator); // TODO: remove this (SimulatedRepository)
//            var location = _context.Location.OrderByDescending(l => l.id).FirstOrDefault(); // TODO: uncomment this
            
            if (ToTheLeftDirection) {
                if (LocationIterator < 232) {
                    LocationIterator++;
                } else {
                    ToTheLeftDirection = false;
                    LocationIterator--;
                }
            } else {
                if (LocationIterator > 2) {
                    LocationIterator--;
                } else {
                    ToTheLeftDirection = true;
                    LocationIterator++;
                }
            }

            return Json(location);
        }

        [HttpGet]
        public IActionResult GetPOIs()
        {            
            return Json(Context.POIs.ToArray());
        }
    }
}
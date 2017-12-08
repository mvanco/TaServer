using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sfx.Data;

namespace TAServer.Controllers
{
    [Produces("application/json")]
    public class TrainAlertController : Controller
    {

        private static int sLocationIterator = 1; // TODO: remove this (SimulatedRepository)
        private static bool toTheLeftDirection = true; // TODO: remove this (SimulatedRepository)
        

        private readonly TrainAlertDBContext _context;

        public TrainAlertController(TrainAlertDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLocation() {
            
            // TODO: remove this (SimulatedRepository)
            var location = _context.Location.FirstOrDefault(location1 => location1.id == sLocationIterator);
            if (toTheLeftDirection) {
                if (sLocationIterator < 232) {
                    sLocationIterator++;
                } else {
                    toTheLeftDirection = false;
                    sLocationIterator--;
                }
            } else {
                if (sLocationIterator > 2) {
                    sLocationIterator--;
                } else {
                    toTheLeftDirection = true;
                    sLocationIterator++;
                }
            }
            
//            var location = _context.Location.OrderByDescending(l => l.id).FirstOrDefault(); // TODO: uncomment this

            return Json(location);
        }

    }
}
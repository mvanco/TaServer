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

        private readonly TaDbContext _context;

        public TrainAlertController(TaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLocation() {

            var location = _context.Location.OrderByDescending(l => l.Id).FirstOrDefault();

            return Json(location);

        }

    }
}
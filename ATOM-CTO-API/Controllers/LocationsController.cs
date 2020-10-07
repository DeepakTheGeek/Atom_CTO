using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATOM_CTO_API.Data;
using ATOM_CTO_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATOM_CTO_API.Controllers
{
    [Route("locations")]
    [ApiController]
    [Produces("application/json")]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _context;
        public LocationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("SaveLocation")]
        public IActionResult SaveLocation([FromBody] LocationPoint locationPoint)
        {
            try
            {
                _context.LocationPoints.Add(locationPoint);
                _context.SaveChanges();
                return Ok("Location Saved Successfully.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please check the data and try again.");
            }
        }

        [HttpGet]
        [Route("GetLocations")]
        public IActionResult GetLocations(decimal? lat, decimal? lon, int? radius)
        {
            var locations = _context.LocationPoints.OrderByDescending(l => l.DateAdded).ToList();

            if (lat != null && lon != null && radius != null)
            {
                List<LocationPoint> locationPointList = new List<LocationPoint>();

                foreach (var locationPoint in locations)
                {
                    if (IsInRange((double)locationPoint.Latitude, (double)locationPoint.Longitude, (double)lat, (double)lon, radius.Value))
                        locationPointList.Add(locationPoint);
                }
                if (locationPointList.Count > 0)
                {
                    return Ok(locationPointList);
                }
                else
                {
                    return NotFound("No Location data found for the given cordindates.");
                }
            }
            else
            {
                return Ok(locations);
            }
        }

        private bool IsInRange(double checkPointLat,double checkPointLng, double centerPointLat, double centerPointLng, int range)
        {
            var ky = 40000 / 360;
            var kx = Math.Cos(Math.PI * centerPointLat / 180.0) * ky;
            var dx = Math.Abs(centerPointLng - checkPointLng) * kx;
            var dy = Math.Abs(centerPointLat - checkPointLat) * ky;

            return Math.Sqrt(dx * dx + dy * dy) <= range;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarsAndPeople.Controllers
{
    [ApiController]
    [Route("api/people/{personId:int}/cars")]
    public class CarsController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public IActionResult GetPersonCars(int personId){
            var person = _context.People.Find(personId);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(_context.CarList!.Where(x => x.OwnerId == personId));
        }
    }
}
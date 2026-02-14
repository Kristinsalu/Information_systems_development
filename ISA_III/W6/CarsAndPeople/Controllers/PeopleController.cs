using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsAndPeople.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsAndPeople
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPeople(Gender? gender)
        {
            var query = _context.People.AsQueryable();

            if (gender.HasValue){
                query = query.Where(x => x.Gender == gender);
            }
            
            var peopleList = await query.ToListAsync();

            if (peopleList.Any())
            {
                return Ok(peopleList); 
            }

            return NotFound("No people found");
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);  
        }  

        [HttpPut]
        public async Task<IActionResult> PutSession(Person person)
        {

            if (!PersonExists(person.Id))
            {
                return NotFound();
            }

             _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            var personExists = await _context.People.AnyAsync(x => x.Id == person.Id);
            
            if (personExists) {
                return BadRequest();
            } 

            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        private bool PersonExists(int id)
        {
            return _context.People!.Any(c => c.Id == id);
        }
    }
}
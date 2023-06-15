using App_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly DataContext _context;
        public ActorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Actor>>> GetActor()
        {
            return Ok(await _context.actors.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Actor>>> CreateActor(Actor actor)
        {
            _context.actors.Add(actor);
            await _context.SaveChangesAsync();

            return Ok(await _context.actors.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Actor>>> UpdateActor(Actor actor)
        {
            var dbActor = await _context.actors.FindAsync(actor.Id);
            if (dbActor == null)
                return BadRequest("Actor not found");

            dbActor.Name = actor.Name;
            dbActor.FirstName = actor.FirstName;
            dbActor.LastName = actor.LastName;
            dbActor.Place = actor.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.actors.ToArrayAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Actor>>> DeleteActor(int id)
        {
            var dbActor = await _context.actors.FindAsync(id);
            if (dbActor == null)
                return BadRequest("Actor not found");

            _context.actors.Remove(dbActor);
            await _context.SaveChangesAsync();

            return Ok(await _context.actors.ToArrayAsync());
        }
    }
}
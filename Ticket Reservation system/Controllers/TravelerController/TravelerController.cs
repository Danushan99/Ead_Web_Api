

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;
using Ticket_Reservation_system.Models.Traveler;
using Ticket_Reservation_system.Services.TravelerService;

namespace Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerService travelerService;

        public TravelerController(ITravelerService travelerService)
        {
            this.travelerService = travelerService;
        }

        // GET: api/<TravelerController>
        [HttpGet]
        public ActionResult<List<Traveler>> Get() => travelerService.Get();

        // GET api/<TravelerController>/5
        [HttpGet("{id}")]
        public ActionResult<Traveler> Get(string id)
        {
            var traveler = travelerService.Get(id);

            if (traveler == null)
            {
                return NotFound($"traveler with id = {id} not found");
            };

            return traveler;
        }

        // POST api/<TravelerController>
        [HttpPost]
        public ActionResult<Traveler> Post([FromBody] Traveler traveler)
        {
            travelerService.Create(traveler);

            return CreatedAtAction(nameof(Get), new { id = traveler.Id }, traveler);
        }

        // PUT api/<TravelerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Traveler traveler)
        {
            var excistingTraveler = travelerService.Get(id);

            if (excistingTraveler == null)
            {
                return NotFound($"Train with id = {id} not found");
            };

            travelerService.Update(id, traveler);

            return NoContent();
        }

        // DELETE api/<TravelerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var traveler = travelerService.Get(id);

            if (traveler == null)
            {
                return NotFound($"traveler with id = {id} not found");
            };

            travelerService.Remove(traveler.Id);

            return Ok($"traveler with Id = {id} deleted");
        }
    }
}

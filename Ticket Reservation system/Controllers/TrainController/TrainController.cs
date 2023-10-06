using Microsoft.AspNetCore.Mvc;
using Ticket_Reservation_system.Models.TrainModel;
using Ticket_Reservation_system.Services.TrainService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService trainService;

        public TrainController(ITrainService trainService)
        {
            this.trainService = trainService;
        }

        // GET: api/<TrainController>
        [HttpGet]
        public ActionResult<List<Train>> Get() => trainService.Get();

        // GET api/<TrainController>/5
        [HttpGet("{id}")]
        public ActionResult<Train> Get(string id)
        {
            var train = trainService.Get(id);

            if (train == null)
            {
                return NotFound($"Train with id = {id} not found");
            };

            return train;
        }

        // POST api/<TrainController>
        [HttpPost]
        public ActionResult<Train> Post([FromBody] Train train)
        {
            trainService.Create(train);

            return CreatedAtAction(nameof(Get), new { id = train.Id }, train);
        }

        // PUT api/<TrainController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Train train)
        {
            var excistingTrain = trainService.Get(id);

            if (excistingTrain == null)
            {
                return NotFound($"Train with id = {id} not found");
            };

            trainService.Update(id, train);

            return NoContent();
        }

        // DELETE api/<TrainController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var train = trainService.Get(id);

            if (train == null)
            {
                return NotFound($"Train with id = {id} not found");
            };

            trainService.Remove(train.Id);

            return Ok($"Train with Id = {id} deleted");
        }
    }
}

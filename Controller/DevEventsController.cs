namespace Name.Controllers
{
    using AwesomeDevEvents.API.Entities;
    using crud_api.persistence;

    using Microsoft.AspNetCore.Mvc;
    [Route("api/events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;


        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public  IActionResult GetAll()
        {
            var devEvent= _context.DevEntities.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvent);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var element = _context.DevEntities.SingleOrDefault(d=> id == d.id);
            if(element == null){
                return NotFound();
            }
            return Ok(element);

        }

        
        [HttpPost()]
         public IActionResult Post(DevEntities devEvent)
        {
            _context.DevEntities.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new { id = devEvent.id}, devEvent);

        }

         [HttpPut("{id}")]
         public IActionResult Update(Guid id ,DevEntities input)
        {
            var element = _context.DevEntities.SingleOrDefault(d=> id == d.id);
            if(element == null){
                return NotFound();
            }

            element.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
         public IActionResult Delete(Guid id)
        {
            var element = _context.DevEntities.SingleOrDefault(d => id == d.id);

            if(element == null){
                return NotFound();
            }

            element.Delete();

            return NoContent();
        }


    }
}
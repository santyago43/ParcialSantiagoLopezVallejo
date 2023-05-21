using ConcertDB.DAL;
using ConcertDB.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcertDB.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class TicketsController : Controller
    {
        private readonly DataBaseContext _DBContext;

        public TicketsController(DataBaseContext dBContext)
        {
            _DBContext = dBContext;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Tickets>> GetTicketByID(Guid? Id)
        {

            var ticket = await _DBContext.Tickets.FirstOrDefaultAsync(a => a.Id == Id);

            if(ticket == null) return NotFound();

            return Ok(ticket);

        }

    }
}

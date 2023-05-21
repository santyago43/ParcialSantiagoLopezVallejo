using ConcertDB.DAL;
using ConcertDB.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Runtime.InteropServices;

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
        public async Task<ActionResult<Tickets>> GetTicketById(Guid? Id, String EntranceGate)
        {
            var ticket = await _DBContext.Tickets.FirstOrDefaultAsync(a => a.Id == Id);

            if (ticket != null)
            {
                if (ticket.IsUsed == false)
                {
                    try
                    {
                        ticket.UseDate = DateTime.Now;
                        ticket.IsUsed = true;
                        ticket.EntranceGate = EntranceGate;

                        _DBContext.Tickets.Update(ticket);
                        await _DBContext.SaveChangesAsync();
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                        if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                            return Conflict("Ya existe");
                    }
                    catch (Exception excep)
                    {
                        return Conflict(excep.Message);
                    }
                    return Ok(ticket);
                }
                return Conflict("La entrada ya se utilizo");
            }
            return NotFound();
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateTicket(Tickets ticket)
        {
            try
            {
                ticket.Id = Guid.NewGuid();

                _DBContext.Tickets.Add(ticket);
                await _DBContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Ya existe"));
            }
            catch (Exception excep)
            {
                return Conflict(excep.Message);
            }

            return Ok(ticket);
        }


    }
}

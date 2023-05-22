using ConcertDB.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace ConcertDB_Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _HTTPClient;

        public TicketsController(IHttpClientFactory HTTPClient)
        {
            _HTTPClient = HTTPClient;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Verificar(Guid id)
        {

                var url = "https://localhost:7268/api/Tickets/Get/078d3167-e89e-455c-ec23-08db5a45cc09";
                var json = await _HTTPClient.CreateClient().GetStringAsync(url);
                Tickets tickets = JsonConvert.DeserializeObject<Tickets>(json);

                if (tickets != null)
                {
                    if (tickets.IsUsed == false)
                    {
                        return View();
                    }
                    
                }
                return NotFound();

            
        }
    }  
}

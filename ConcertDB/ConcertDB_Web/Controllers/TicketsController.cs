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

        [HttpPut, ActionName("Verificar")]
        public async Task<ActionResult> Verificar(Guid id, String entranceGate)
        {

            try
            {

                var url = String.Format("https://localhost:7268/api/Tickets/Get/{0}", id);
                var json = await _HTTPClient.CreateClient().GetStringAsync(url);
                Tickets tickets = JsonConvert.DeserializeObject<Tickets>(json);

                if (tickets != null)
                {
                    return View(tickets);
                }
                return View("El tiquete no existe");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }  
}

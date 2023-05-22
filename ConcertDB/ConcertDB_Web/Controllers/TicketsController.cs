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

        
    }  
}

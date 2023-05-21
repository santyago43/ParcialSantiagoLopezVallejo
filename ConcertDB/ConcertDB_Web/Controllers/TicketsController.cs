using Microsoft.AspNetCore.Mvc;

namespace ConcertDB_Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _HTTPClient;
        private readonly IConfiguration _Configuration;



        public TicketsController(IHttpClientFactory HTTPClient, IConfiguration Configuration)
        {
            _HTTPClient = HTTPClient;
            _Configuration = Configuration;
        }

        public IActionResult Index()
        {
            return View();
        }





    }
}

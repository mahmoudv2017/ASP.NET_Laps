using Day2.Models.Domain;
using Day2.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Day2.Controllers
{
    public class TicketController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("hello from TicketController");
            return View(Ticket.AllTickets);
        }

        [HttpGet]
        public IActionResult ADD()
        {


            var count = Enum.GetValues(typeof(Severity)).Length;
            var arrays = Enum.GetValues(typeof(Severity));

            var lister = Enumerable.Range(0, count).Select(i => new SelectListItem(arrays.GetValue(i).ToString(), i.ToString())) ;

            ViewData.Add("tickets" , lister);  
            return View("add");
        }

        [HttpPost]
        public IActionResult ADDTicket(AddTicketVM newTicket)
        {
            _logger.LogInformation(newTicket.ToString());
            Ticket.AllTickets.Add(new Ticket { CreatedDate = newTicket.CreatedDate , Description = newTicket.Description , IsClosed = newTicket.IsClosed , Severity = newTicket.Severity});


            return RedirectToAction("index");
            //return View("add");
        }

    }
}

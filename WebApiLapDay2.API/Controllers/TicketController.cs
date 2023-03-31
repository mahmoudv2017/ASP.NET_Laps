using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLapDay2.BL.Dtos;
using WebApiLapDay2.BL.Managers.Ticket;

namespace WebApiLapDay2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketManager _ticketmnager;
        public TicketController( ITicketManager ticketManager )
        {
            _ticketmnager= ticketManager;   
        }
        [HttpGet]
        public ActionResult<List<TicketDtosRead>> GetAll()
        {
            return _ticketmnager.GetAll();
        }

        [HttpPost]

        public ActionResult Create(TicketDtosCreate dto )
        {
            _ticketmnager.Add(dto);
            return Ok("Record Saved Successfully");
        }
    }
}

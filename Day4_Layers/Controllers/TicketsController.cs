using Microsoft.AspNetCore.Mvc;
using TicketLayer.BL.Managers.Tickets;

namespace TicketsLayer.MVC.Controllers;

public class TicketController : Controller
{
    private ITickersManager _ticketsManager;
    public TicketController(ITickersManager ticketsManager)
    {
        _ticketsManager = ticketsManager;
    }
    public IActionResult Index()
    {
        return View(_ticketsManager.GetALL());
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Read(int id)
    {
        return View(_ticketsManager.Get(id));
    }
}

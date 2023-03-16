using Microsoft.AspNetCore.Mvc;
using TicketLayer.BL.Managers.Tickets;

namespace TicketsLayer.MVC.Controllers;

public class TicketController : Controller
{
    private ITickersManager _ticketsManager;
    public TicketController(ITickersManager ticketsManager)
    {
        _ticketsManager=ticketsManager;
    }
    public IActionResult Index()
    {
        return View(_ticketsManager.GetALL());
    }
}

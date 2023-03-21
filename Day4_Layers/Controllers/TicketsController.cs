using Microsoft.AspNetCore.Mvc;
using TicketLayer.BL.Managers.Departments;
using TicketLayer.BL.Managers.Developers;
using TicketLayer.BL.Managers.Tickets;
using TicketLayer.BL.ViewModels.Tickets;

namespace TicketsLayer.MVC.Controllers;

public class TicketController : Controller
{
    private ITickersManager _ticketsManager;
    private IDeparmtentsManager _departmentManager;
    private IDeveloperManager _developerManager;
    public TicketController(ITickersManager ticketsManager , IDeparmtentsManager departmentManager , IDeveloperManager developerManager)
    {
        _ticketsManager = ticketsManager;
        _departmentManager = departmentManager;
        _developerManager = developerManager;
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

    [HttpPost]
    [Route("Edit/{id:int}")]
    public IActionResult Edit(TicketsEditVM ticket)
    {
        _ticketsManager.update(ticket);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route("Edit/{id:int}")]
    public IActionResult Edit(int id)
    {
        ViewData.Add("Departments", _departmentManager.GetAll());
        ViewData.Add("Developers" , _developerManager.GetAll());

        return View("add",_ticketsManager.PageForEdit(id));
    }

    [HttpGet]
    [Route("delete/{id:int}")]
    public IActionResult delete(int id)
    {
        _ticketsManager.delete(id);

        return RedirectToAction(nameof(Index));
    }


}

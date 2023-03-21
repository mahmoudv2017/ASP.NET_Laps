using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketLayer.BL.Managers.Departments;
using TicketLayer.BL.Managers.Developers;
using TicketLayer.BL.ViewModels.Tickets;
using TicketsLayer.DAL.Repos.DepartmentRepo;
using TicketsLayer.DAL.Repos.DeveloperRepo;
using TicketsLayer.DAL.Repos.TicketRepo;
using Your_Project_Name.Models.Domain;

namespace TicketLayer.BL.Managers.Tickets;

public class TicketsManager : ITickersManager
{
    private ITicketRepo _ticketRepo;
    private IDeparmtentsManager _departmentRepo;
    private IDeveloperManager _developerRepo;
    public TicketsManager(ITicketRepo tickerRepo , IDeparmtentsManager departmentRepo , IDeveloperManager DeveloperRepo)
    {
        _ticketRepo= tickerRepo;
        _departmentRepo = departmentRepo;
        _developerRepo= DeveloperRepo;
    }

    public TicketIndexVM Get(int id)
    {
        Ticket TicketToSHow = _ticketRepo.Get(id);

        return new TicketIndexVM {
            Id = TicketToSHow.Id,
            Severity = TicketToSHow.Severity, DepartmentName = TicketToSHow.Department!.Name ?? " ",
            Description = TicketToSHow.Description, IsClosed = TicketToSHow.IsClosed,
            DeveloperCount = TicketToSHow.Developers.Count.ToString()};
    }

    public List<TicketIndexVM> GetALL()
    {
        var tickets = _ticketRepo.GetAll();
        return _ticketRepo.GetAll().Select( e => new TicketIndexVM { Id=e.Id, Severity=e.Severity , DepartmentName=e.Department?.Name ?? " " , Description=e.Description , IsClosed=e.IsClosed , DeveloperCount=e.Developers.Count.ToString()} ).ToList();
    }

    public TicketsEditVM PageForEdit(int id)
    {
        var ticker = _ticketRepo.Get(id);
        var departments = _departmentRepo.GetAll();
        var developers = _developerRepo.GetAll();

        return new TicketsEditVM { Developers= developers, IsClosed = ticker.IsClosed, Description = ticker.Description, Departments = departments, Severity = ticker.Severity };
    }

    public void update(TicketsEditVM tvm)
    {
        //var tickerToUpdate = _ticketRepo.Get(tvm.Id);
        //tickerToUpdate.Description = tvm.Description;
        //tickerToUpdate.Severity= tvm.Severity;
        //tickerToUpdate.de = tvm.Departments;
        //tickerToUpdate.IsClosed = tvm.IsClosed;

        //_ticketRepo.Update(tickerToUpdate);
        //_ticketRepo.Save();
    }
}



using System.Diagnostics;
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
    private IDepartmentRepo _departmentRepo;
    private IDeveloperRepo _developerRepo;
    public TicketsManager(ITicketRepo tickerRepo , IDepartmentRepo departmentRepo , IDeveloperRepo DeveloperRepo)
    {
        _ticketRepo= tickerRepo;
        _developerRepo = DeveloperRepo;
        _departmentRepo = departmentRepo;
    }

    public void delete(int id)
    {
        var TicketToRemove = _ticketRepo.Get(id);
        _ticketRepo.Delete(TicketToRemove);
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

        
        return new TicketsEditVM { Id=ticker.Id , Title=ticker.Title , IsClosed = ticker.IsClosed, Description = ticker.Description,  Severity = ticker.Severity };
    }

    public void update(TicketsEditVM tvm)
    {

        var tickerToUpdate = _ticketRepo.Get(tvm.Id);
        tickerToUpdate.Description = tvm.Description;
        tickerToUpdate.Severity = tvm.Severity;
        tickerToUpdate.Developers =   _developerRepo.GetAll().Where(dev => (tvm.Developers.Contains(dev.Id))).ToList();
        tickerToUpdate.IsClosed = tvm.IsClosed;
        tickerToUpdate.Dept_id = _departmentRepo.Get(tvm.Departments)!.Id;

        _ticketRepo.Update(tickerToUpdate);
        _ticketRepo.Save();
    }
}

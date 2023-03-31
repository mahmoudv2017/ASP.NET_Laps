using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLapDay2.BL.Dtos;

using WebApiLapDay2.DAL.Repos.Ticket;

namespace WebApiLapDay2.BL.Managers.Ticket;
using WebApiLapDay2.DAL.Models;

public class TicketManager : ITicketManager
{
    private readonly IticketRepo _TicketRepo;

    public TicketManager(IticketRepo iticketRepo)
    {
        _TicketRepo= iticketRepo;
    }
    public void Add(TicketDtosCreate tdo)
    {
        var newTicket = new Ticket()
        {
         
            Description = tdo.Description,
            EstimationCost = tdo.EstimationCost,
            Severity = Severity.critical,
            Title = tdo.Title,

        };

        _TicketRepo.add(newTicket);
        _TicketRepo.Save();
    }

    public List<TicketDtosRead> GetAll()
    {
        return _TicketRepo.GetTicketWithDeveloeprs().Select(tick => new TicketDtosRead
        {
            Description = tick.Description,
            Id = tick.Id,
            Severity = Severity.critical,
            Title = tick.Title,
        }).ToList();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketLayer.BL.ViewModels.Tickets;
using TicketsLayer.DAL.Repos.TicketRepo;

namespace TicketLayer.BL.Managers.Tickets;

public class TicketsManager : ITickersManager
{
    private ITicketRepo _ticketRepo;
    public TicketsManager(ITicketRepo tickerRepo)
    {
        _ticketRepo= tickerRepo;
    }
    public List<TicketIndexVM> GetALL()
    {
        
        return _ticketRepo.GetAll().Select( e => new TicketIndexVM { Severity=e.Severity , Dept_ID=e.Dept_id , Description=e.Description , IsClosed=e.IsClosed} ).ToList();
    }

    public TicketsEditVM PageForEdit(int id)
    {
        var ticker = _ticketRepo.Get(id);

        return new TicketsEditVM { IsClosed = ticker.IsClosed, Description = ticker.Description, Dept_ID = ticker.Dept_id, Severity = ticker.Severity };
    }

    public void update(TicketsEditVM tvm)
    {
        var tickerToUpdate = _ticketRepo.Get(tvm.Id);
        tickerToUpdate.Description = tvm.Description;
        tickerToUpdate.Severity= tvm.Severity;
        tickerToUpdate.Dept_id = tvm.Dept_ID;
        tickerToUpdate.IsClosed = tvm.IsClosed;

        _ticketRepo.Update(tickerToUpdate);
        _ticketRepo.Save();
    }
}

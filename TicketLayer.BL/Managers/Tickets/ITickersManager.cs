using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketLayer.BL.ViewModels.Tickets;

namespace TicketLayer.BL.Managers.Tickets;

public interface ITickersManager
{
    public List<TicketIndexVM> GetALL();

    TicketIndexVM Get(int id);
    TicketsEditVM PageForEdit(int id);
    //public List<TicketIndexVM> GetTicketWithDeparments();

    //public List<TicketIndexVM> GetTicketWithDevelopers();
    void delete(int id);
    void update(TicketsEditVM tvm);
}

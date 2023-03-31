using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLapDay2.BL.Dtos;

namespace WebApiLapDay2.BL.Managers.Ticket
{
    public interface ITicketManager
    {
        List<TicketDtosRead> GetAll();

        void Add(TicketDtosCreate tdo);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApiLapDay2.DAL.Repos.Ticket;
using WebApiLapDay2.DAL.Models;
public interface IticketRepo:GlobalInterface<Ticket>
{
    public List<Ticket> GetTicketWithDeveloeprs();
}

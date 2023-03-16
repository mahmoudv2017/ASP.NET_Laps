using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsLayer.DAL.Context;
using Your_Project_Name.Models.Domain;

namespace TicketsLayer.DAL.Repos.TicketRepo;

public class TickerRepo : ITicketRepo
{
    private readonly TicketContext _Ticketcontext;
    public TickerRepo(TicketContext Context)
    {
        _Ticketcontext = Context;
    }
    public Ticket Get(int id)
    {
        return _Ticketcontext.Tickets.First(t => t.Id == id);
    }

    public List<Ticket> GetAll()
    {
        return _Ticketcontext.Tickets.ToList();
    }

    public void Save()
    {
        _Ticketcontext.SaveChanges();
    }

    public void Update(Ticket ticket)
    {
        //implementation not needed because of the change tracker
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsLayer.DAL.Context;
using Your_Project_Name.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace TicketsLayer.DAL.Repos.TicketRepo;

public class TickerRepo : ITicketRepo
{
    private readonly TicketContext _Ticketcontext;
    public TickerRepo(TicketContext Context)
    {
        _Ticketcontext = Context;
    }

    public void Delete(Ticket ticket)
    {
         _Ticketcontext.Set<Ticket>().Remove(ticket);
        Save();
    }


    public Ticket Get(int id)
    {
        return _Ticketcontext.Tickets.Include(e => e.Department).Include(e => e.Developers).First(t => t.Id == id);
    }

    public List<Ticket> GetAll()
    {
        return _Ticketcontext.Tickets.Include(e => e.Department).Include(e=>e.Developers).ToList();
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

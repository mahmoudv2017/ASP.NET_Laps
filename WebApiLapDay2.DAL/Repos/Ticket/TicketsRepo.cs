using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApiLapDay2.DAL.Repos.Ticket;

using Microsoft.EntityFrameworkCore;
using WebApiLapDay2.DAL.Context;
using WebApiLapDay2.DAL.Models;
public class TicketsRepo : GlobalRepo<Ticket>, IticketRepo
{
    private readonly MyDbContext _context; 
    public TicketsRepo(MyDbContext myDbContext) : base(myDbContext)
    {
        _context = myDbContext;
    }

    public List<Ticket> GetTicketWithDeveloeprs()
    {
       return _context.Ticket.Include(ticker => ticker.Developers).ToList();
    }
}

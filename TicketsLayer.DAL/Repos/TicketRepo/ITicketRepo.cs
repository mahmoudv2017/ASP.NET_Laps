using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Your_Project_Name.Models.Domain;

namespace TicketsLayer.DAL.Repos.TicketRepo;

public interface ITicketRepo
{
    public List<Ticket> GetAll();

    public Ticket Get(int id);

    void Save();

    void Update(Ticket ticket);
    void Delete(Ticket ticket);
}


using TicketsLayer.DAL.Context;
using TicketsLayer.DAL.Models;

namespace TicketsLayer.DAL.Repos.DeveloperRepo
{
    public class DeveloperRepo : IDeveloperRepo

    {
        private TicketContext _ticketContext;
        public DeveloperRepo( TicketContext ticketContext )
        {
            _ticketContext = ticketContext;
        }
        public void Delete(Developer dev)
        {
            _ticketContext.Set<Developer>().Remove(dev);
        }

        public Developer? Get(int id)
        {
           return _ticketContext.Set<Developer>().FirstOrDefault(dev => dev.Id == id);
        }

        public List<Developer> GetAll()
        {
            return _ticketContext.Set<Developer>().ToList();
        }

        public void Save()
        {
            _ticketContext.SaveChanges();
        }
    }
}

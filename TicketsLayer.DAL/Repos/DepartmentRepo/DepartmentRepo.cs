

using TicketsLayer.DAL.Context;
using TicketsLayer.DAL.Models;

namespace TicketsLayer.DAL.Repos.DepartmentRepo;

public class DepartmentRepo : IDepartmentRepo
{
    private TicketContext _ticketContext;
    public DepartmentRepo(TicketContext ticketContext)
    {
        _ticketContext= ticketContext;
    }
    public void Delete(Department dev)
    {
        _ticketContext.Set<Department>().Remove(dev);
    }

    public Department? Get(int id)
    {
        return _ticketContext.Set<Department>().FirstOrDefault(dep => dep.Id==id);
    }

    public List<Department> GetAll()
    {
        return _ticketContext.Set<Department>().ToList();
    }

    public void Save()
    {
         _ticketContext.SaveChanges();
    }
}


using TicketsLayer.DAL.Models;


namespace TicketsLayer.DAL.Repos.DeveloperRepo;

public interface IDeveloperRepo
{
    public List<Developer> GetAll();

    public Developer? Get(int id);

    void Save();
    public void Delete(Developer dev);
}

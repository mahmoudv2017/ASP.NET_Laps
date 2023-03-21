

using TicketsLayer.DAL.Models;

namespace TicketsLayer.DAL.Repos.DepartmentRepo;

public interface IDepartmentRepo
{
    public List<Department> GetAll();

    public Department? Get(int id);

    void Save();
    public void Delete(Department dev);
}

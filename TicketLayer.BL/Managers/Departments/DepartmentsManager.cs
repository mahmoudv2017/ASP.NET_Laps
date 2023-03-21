
using Microsoft.AspNetCore.Mvc.Rendering;


using TicketsLayer.DAL.Repos.DepartmentRepo;

namespace TicketLayer.BL.Managers.Departments;

public class DepartmentsManager : IDeparmtentsManager
{
    private IDepartmentRepo _department_repo ;
    public DepartmentsManager(IDepartmentRepo department_repo)
    {
        _department_repo = department_repo;
    }
    public IEnumerable<SelectListItem> GetAll()
    {
        return _department_repo.GetAll().Select(dep => new SelectListItem { Text=dep.Name , Value=dep.Id.ToString()});
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketsLayer.DAL.Repos.DeveloperRepo;

namespace TicketLayer.BL.Managers.Developers;

public class DeveloperManager : IDeveloperManager
{
    private readonly IDeveloperRepo _developerRepo;
         
    public DeveloperManager(IDeveloperRepo developerRepo)
    {
        _developerRepo = developerRepo;
    }
    public IEnumerable<SelectListItem> GetAll()
    {
        return _developerRepo.GetAll().Select(dev => new SelectListItem { Text=dev.FirstName + " "+dev.LastName  , Value=dev.Id.ToString()});
    }
}

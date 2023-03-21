
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TicketLayer.BL.Managers.Developers;

public interface IDeveloperManager
{
    public IEnumerable<SelectListItem> GetAll();
}

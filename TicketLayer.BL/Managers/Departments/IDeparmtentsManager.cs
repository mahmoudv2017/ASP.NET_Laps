using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketsLayer.DAL.Context;

namespace TicketLayer.BL.Managers.Departments;

public interface IDeparmtentsManager
{

    public IEnumerable<SelectListItem> GetAll();
}

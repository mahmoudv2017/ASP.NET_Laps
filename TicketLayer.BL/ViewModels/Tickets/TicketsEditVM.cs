using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Your_Project_Name.Models.Domain;

namespace TicketLayer.BL.ViewModels.Tickets;

public class TicketsEditVM
{
    public int Id { get; set; } 
    public string Description { get; set; } = string.Empty;

    [Display(Name = "is Closed ?")]
    public bool IsClosed { get; set; }

    public Severity Severity { get; set; }

    public IEnumerable<SelectListItem>? Departments { get; set; } //should be a collection
    public IEnumerable<SelectListItem>? Developers { get; set; }
}

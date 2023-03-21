using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Your_Project_Name.Models.Domain;

namespace TicketLayer.BL.ViewModels.Tickets;

public record TicketIndexVM
{
    public int Id { get; set; }
    public string Description { get; set; }=string.Empty;

    public string Title { get; set; } = string.Empty;

    [Display(Name ="is Closed ?")]
    public bool IsClosed { get; set; }

    public Severity Severity { get; set; }

    [Display(Name ="Department Name")]
    public string DepartmentName { get; set; }= string.Empty;

    [Display(Name = "Developer Count")]
    public string DeveloperCount { get; set; } = string.Empty;
}

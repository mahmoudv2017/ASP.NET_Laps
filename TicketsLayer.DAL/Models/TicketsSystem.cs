using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using TicketsLayer.DAL.Models;

namespace Your_Project_Name.Models.Domain;

public enum Severity
{
    Low,
    Medium,
    High
}




public class Ticket
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsClosed { get; set; }
    public Severity Severity { get; set; }

    public string Title { get; set; }=string.Empty;
    
    public int Dept_id { get; set; }
    public Department? Department { get; set; }
    #region Initial List

    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();

    #endregion


}
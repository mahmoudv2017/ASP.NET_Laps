using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Your_Project_Name.Models.Domain;

namespace TicketsLayer.DAL.Models;

public class Department
{
  
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;



    #region Initial List


    #endregion



    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}

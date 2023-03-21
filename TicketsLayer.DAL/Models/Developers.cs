using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Your_Project_Name.Models.Domain;

namespace TicketsLayer.DAL.Models;

public class Developer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;


    public int DepartmentID { get; set; }

   

    public Department? Department { get; set; }


    public ICollection<Ticket> Issues { get; set; } = new HashSet<Ticket>();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLapDay2.DAL.Models;

public class Departments
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Developer>? developers { get; set; } 
}

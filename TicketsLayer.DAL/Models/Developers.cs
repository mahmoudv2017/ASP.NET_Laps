using System;
using System.Collections.Generic;
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
    public int Dept_ID { get; set; }
    #region Initial List

    private static List<Developer> _developers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":"0b731ee0-a2a0-4120-8211-76b161f64535","FirstName":"Freddie","LastName":"Johnson"},{"Id":"6001109e-314f-46dd-be5c-9703a1a4fb51","FirstName":"Sophia","LastName":"O\u0027Keefe"},{"Id":"dd56d068-ef7b-4226-91eb-35fb10aa2d6d","FirstName":"Angela","LastName":"McClure"},{"Id":"1c1bf402-5fe3-497a-9c57-475ff7ce1487","FirstName":"Jamie","LastName":"Berge"},{"Id":"d9d44861-081b-4c33-a415-c3146b38aa5d","FirstName":"Geoffrey","LastName":"Abbott"}]""") ?? new();

    #endregion

    public static List<Developer> GetDevelopers() => _developers;
    
    public ICollection<Dev_Tickets> Tickets = new HashSet<Dev_Tickets>();

    public Department Department { get; set; } = new Department();
}

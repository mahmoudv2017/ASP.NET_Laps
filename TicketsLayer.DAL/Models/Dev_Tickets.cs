using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Your_Project_Name.Models.Domain;

namespace TicketsLayer.DAL.Models;

public class Dev_Tickets
{
    public int Dev_id { get; set; }
    public int Ticket_id { get; set; }

    public Developer Developer { get; set; }= new Developer();
    public Ticket Ticket { get; set; } = new Ticket();
}

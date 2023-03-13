using Day2.Models.View;
using System.ComponentModel.DataAnnotations;

namespace Day2.Models.Domain
{
    public enum Severity
    {
        low,medium,high
    }
    public class Ticket
    {
       
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; } = string.Empty;


        public bool IsClosed { get; set; }


        public Severity Severity { get; set; }

        public static List<Ticket> AllTickets { get; set; }= new List<Ticket>();

        


    }
}

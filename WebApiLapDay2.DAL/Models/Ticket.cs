using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLapDay2.DAL.Models
{
    public enum Severity
    {
        Warning,info,critical
    }
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }=string.Empty;

        public Severity? Severity { get; set; }

        public string Title { get; set; }=string.Empty;
        public double EstimationCost { get; set; }

        public ICollection<Developer>? Developers { get; set; }  


    }
}

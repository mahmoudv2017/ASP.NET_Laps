using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLapDay2.DAL.Models;

namespace WebApiLapDay2.BL.Dtos
{
    public class TicketDtosRead
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public Severity? Severity { get; set; }

        public string Title { get; set; } = string.Empty;
        //public double EstimationCost { get; set; }

   
    }


    public class TicketDtosCreate
    {
        //public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

       // public Severity? Severity { get; set; }

        public string Title { get; set; } = string.Empty;
        public double EstimationCost { get; set; }



    }
}

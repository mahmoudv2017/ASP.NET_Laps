using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLapDay2.DAL.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }

        public int DepartmentsID { get; set; }
        public Departments? Departments { get; set; }
    }
}

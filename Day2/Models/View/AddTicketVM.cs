using Day2.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Day2.Models.View
{
    public record AddTicketVM
    {
        [DataType(DataType.Date)]


        public DateTime CreatedDate { get; init; }
        public string Description { get; init; } = string.Empty;

        [Display(Name = "Is CLosed")]
        public bool IsClosed { get; init; }

        public Severity Severity { get; init; }

    }
}

using System.ComponentModel.DataAnnotations;
using WebAPIDay1.Validations;

namespace WebAPIDay1.Models
{
    public class Cars // not a record because of the editing
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

        [Required]
        [StringLength(maximumLength:15 , MinimumLength=1 , ErrorMessage ="{0} shoud be between {2} and {1}")]
        public string Model { get; set; } = string.Empty;

        [DatInPast]
        public DateTime ProductionDate { get; set; }


        public string Type { get; set; }=string.Empty;

        public static List<Cars> _Cars= new() {
            
            new Cars {Id=1 , Name="Mercedes G75"  ,Model="Mercedes" , Type="Gas" },
            new Cars {Id=2 , Name="M3"  ,Model="BMW" , Type="Gas" },
            new Cars {Id=3 , Name="scode t3"  ,Model="scoda" , Type = "Gas" },

        };

        public static List<Cars> GetCars() { return _Cars; }
    }
}

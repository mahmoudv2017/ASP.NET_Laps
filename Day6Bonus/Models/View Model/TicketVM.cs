using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day6Bonus.Models.View_Model
{
    public record TicketVM
    {
        [StringLength(20 , MinimumLength =1 , ErrorMessage ="{0} should be between {2} and {1}")]
        [Required]
        [Remote(action:"TitleValidation",controller:"Ticket")]
        public string Title { get; init; } = string.Empty;


        public IFormFile? Image { get; init; }
    }
}

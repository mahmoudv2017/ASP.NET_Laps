using System.ComponentModel.DataAnnotations;

namespace WebAPIDay1.Validations;

public class DatInPastAttribute:ValidationAttribute
{
    public override bool IsValid(object? value) => value is DateTime P_date && P_date < DateTime.Now;
            
        
    
    
}

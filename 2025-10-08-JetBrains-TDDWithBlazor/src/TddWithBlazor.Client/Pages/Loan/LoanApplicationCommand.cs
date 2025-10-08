using System.ComponentModel.DataAnnotations;

namespace TddWithBlazor.Client.Pages.Loan;

public class LoanApplicationCommand
{
    [Required]
    public string FirstName { get; set; } = "";
    
    [Required]
    public string LastName { get; set; } = "";
    
    public string FullName => $"{FirstName} {LastName}";
}
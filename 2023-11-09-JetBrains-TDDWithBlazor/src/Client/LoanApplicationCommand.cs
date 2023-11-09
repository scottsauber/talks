using System.ComponentModel.DataAnnotations;

namespace BlazorTddDemo.Client;

public record LoanApplicationCommand
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}
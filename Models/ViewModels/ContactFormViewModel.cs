using System.ComponentModel.DataAnnotations;

namespace Takyon.Models.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "Please enter your full name.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid corporate email address.")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Organization / Company")]
    [StringLength(120, ErrorMessage = "Organization name cannot exceed 120 characters.")]
    public string? Organization { get; set; }

    [Display(Name = "Solution Area of Interest")]
    public string? ServiceInterest { get; set; }

    [Required(ErrorMessage = "Please enter your message or project inquiry.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 2000 characters.")]
    [Display(Name = "Project Inquiry / Message")]
    public string Message { get; set; } = string.Empty;
}

public class NewsletterFormViewModel
{
    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;
}

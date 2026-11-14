using System.ComponentModel.DataAnnotations;

namespace supercloudserver.Models;

public class GetStartedViewModel
{
    [Required(ErrorMessage = "Please enter your full name.")]
    [Display(Name = "Full Name")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your phone number.")]
    [Phone(ErrorMessage = "Please provide a valid phone number.")]
    [Display(Name = "Phone Number")]
    public string Phone { get; set; } = string.Empty;

    [Display(Name = "Company")]
    public string? Company { get; set; }

    [Required(ErrorMessage = "Please select a platform (Linux or Windows).")]
    [Display(Name = "Platform")]
    public string Platform { get; set; } = "Linux";

    [Required(ErrorMessage = "Please select a cloud server plan.")]
    [Display(Name = "Plan")]
    public string Plan { get; set; } = "20 GB (₹500/month)";

    [Display(Name = "Domain Name")]
    public string? DomainName { get; set; }

    [Display(Name = "Anything we should know?")]
    public string? Message { get; set; }

    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to be contacted about your cloud server request.")]
    [Display(Name = "I agree to be contacted about my cloud server request.")]
    public bool Consent { get; set; }
}

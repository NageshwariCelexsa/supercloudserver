namespace supercloudserver.Models;

public class SubmissionResultViewModel
{
    public bool Success { get; set; }
    public string ReferenceNumber { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public string Plan { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}

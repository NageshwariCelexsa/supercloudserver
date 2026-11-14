namespace supercloudserver.Models;

public class FaqItem
{
    public string Id { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string Category { get; set; } = "General"; // "General", "Plans & Billing", "Technical", "Security & Support"
}

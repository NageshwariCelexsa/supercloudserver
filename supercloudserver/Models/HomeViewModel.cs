namespace supercloudserver.Models;

public class HomeViewModel
{
    public List<CloudPlan> LinuxPlans { get; set; } = new();
    public List<CloudPlan> WindowsPlans { get; set; } = new();
    public List<FaqItem> Faqs { get; set; } = new();
    public GetStartedViewModel FormModel { get; set; } = new();
    public string ActivePlatformTab { get; set; } = "Linux";
    public string? SelectedPlanId { get; set; }
    public string? SubmissionStatus { get; set; }
    public string? SubmissionMessage { get; set; }
    public string? ReferenceCode { get; set; }
}

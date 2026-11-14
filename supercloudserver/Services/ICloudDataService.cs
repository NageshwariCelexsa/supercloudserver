using supercloudserver.Models;

namespace supercloudserver.Services;

public interface ICloudDataService
{
    List<CloudPlan> GetLinuxPlans();
    List<CloudPlan> GetWindowsPlans();
    List<FaqItem> GetFaqs();
    SubmissionResultViewModel SubmitLead(GetStartedViewModel model);
}

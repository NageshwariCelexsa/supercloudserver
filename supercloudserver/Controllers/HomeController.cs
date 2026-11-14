using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using supercloudserver.Models;
using supercloudserver.Services;

namespace supercloudserver.Controllers;

public class HomeController : Controller
{
    private readonly ICloudDataService _cloudDataService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ICloudDataService cloudDataService, ILogger<HomeController> logger)
    {
        _cloudDataService = cloudDataService;
        _logger = logger;
    }

    public IActionResult Index(string? platform, string? plan)
    {
        var vm = BuildHomeViewModel(platform, plan);

        if (TempData["SuccessMessage"] != null)
        {
            vm.SubmissionStatus = "SUCCESS";
            vm.SubmissionMessage = TempData["SuccessMessage"]?.ToString();
            vm.ReferenceCode = TempData["ReferenceCode"]?.ToString();
        }

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SubmitRequest(GetStartedViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(new { success = false, message = "Please check all required fields.", errors });
            }

            var vm = BuildHomeViewModel(model.Platform, model.Plan);
            vm.FormModel = model;
            vm.SubmissionStatus = "ERROR";
            vm.SubmissionMessage = "We couldn't send your request from this page. Please correct the highlighted errors or contact us directly at +91 7401 6666 33.";
            return View("Index", vm);
        }

        var result = _cloudDataService.SubmitLead(model);
        _logger.LogInformation("New Cloud Server lead received: {Ref} - {Name} ({Email}, {Platform} {Plan})", 
            result.ReferenceNumber, result.FullName, result.Email, result.Platform, result.Plan);

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return Json(new 
            { 
                success = true, 
                referenceNumber = result.ReferenceNumber,
                message = result.Message,
                fullName = result.FullName,
                platform = result.Platform,
                plan = result.Plan
            });
        }

        TempData["SuccessMessage"] = result.Message;
        TempData["ReferenceCode"] = result.ReferenceNumber;
        TempData["CustomerName"] = result.FullName;
        TempData["CustomerEmail"] = result.Email;
        TempData["SelectedPlan"] = $"{result.Platform} {result.Plan}";

        return RedirectToAction(nameof(Confirmation));
    }

    public IActionResult Confirmation()
    {
        if (TempData["ReferenceCode"] == null)
        {
            return RedirectToAction(nameof(Index));
        }

        var result = new SubmissionResultViewModel
        {
            Success = true,
            ReferenceNumber = TempData["ReferenceCode"]?.ToString() ?? "SCS-2026-ONLINE",
            Message = TempData["SuccessMessage"]?.ToString() ?? "Your request has been received.",
            FullName = TempData["CustomerName"]?.ToString() ?? "Customer",
            Email = TempData["CustomerEmail"]?.ToString() ?? "",
            Plan = TempData["SelectedPlan"]?.ToString() ?? "Cloud Server Plan",
            SubmittedAt = DateTime.UtcNow
        };

        return View(result);
    }

    public IActionResult Plans(string? platform)
    {
        var vm = BuildHomeViewModel(platform, null);
        return View(vm);
    }

    public IActionResult Compare()
    {
        var vm = BuildHomeViewModel(null, null);
        return View(vm);
    }

    public IActionResult Contact(string? platform, string? plan)
    {
        var form = new GetStartedViewModel();
        if (!string.IsNullOrEmpty(platform)) form.Platform = platform;
        if (!string.IsNullOrEmpty(plan)) form.Plan = plan;
        return View(form);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private HomeViewModel BuildHomeViewModel(string? platform, string? plan)
    {
        var activePlatform = string.Equals(platform, "Windows", StringComparison.OrdinalIgnoreCase) ? "Windows" : "Linux";
        
        var formModel = new GetStartedViewModel
        {
            Platform = activePlatform
        };

        if (!string.IsNullOrWhiteSpace(plan))
        {
            formModel.Plan = plan switch
            {
                "1gb" or "1 GB" => "1 GB (₹250/month)",
                "20gb" or "20 GB" => "20 GB (₹500/month)",
                "unlimited" or "Unlimited" => "Unlimited (₹2,500/month)",
                _ => plan
            };
        }

        return new HomeViewModel
        {
            LinuxPlans = _cloudDataService.GetLinuxPlans(),
            WindowsPlans = _cloudDataService.GetWindowsPlans(),
            Faqs = _cloudDataService.GetFaqs(),
            ActivePlatformTab = activePlatform,
            FormModel = formModel,
            SelectedPlanId = plan
        };
    }
}

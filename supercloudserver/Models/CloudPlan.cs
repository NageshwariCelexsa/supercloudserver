namespace supercloudserver.Models;

public class CloudPlan
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Platform { get; set; } = "Linux"; // "Linux" or "Windows"
    public string DiskSpace { get; set; } = string.Empty;
    public string DataTransfer { get; set; } = string.Empty;
    public string EmailAccounts { get; set; } = string.Empty;
    public decimal PriceMonthlyInr { get; set; }
    public decimal PriceMonthlyUsd { get; set; }
    public decimal PriceAnnualInr => Math.Round(PriceMonthlyInr * 12 * 0.85m); // 15% discount
    public decimal PriceAnnualUsd => Math.Round(PriceMonthlyUsd * 12 * 0.85m, 2);
    public bool IsPopular { get; set; }
    public string Tagline { get; set; } = string.Empty;
    public List<string> Highlights { get; set; } = new();
    public string ControlPanel { get; set; } = "cPanel";
    public string Databases { get; set; } = "Unlimited MySQL";
    public string UptimeSla { get; set; } = "99.99%";
    public string DedicatedHardware { get; set; } = "Pooled Dedicated Nodes, Never Shared";
    public string BackupSchedule { get; set; } = "Automated Backups Every 5 Days";
    public string SupportLevel { get; set; } = "24x7x365 Priority Support";
}

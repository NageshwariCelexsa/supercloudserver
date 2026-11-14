using System.Collections.Concurrent;
using supercloudserver.Models;

namespace supercloudserver.Services;

public class CloudDataService : ICloudDataService
{
    private static readonly ConcurrentBag<GetStartedViewModel> Leads = new();

    public List<CloudPlan> GetLinuxPlans()
    {
        return new List<CloudPlan>
        {
            new CloudPlan
            {
                Id = "linux-1gb",
                Name = "Linux Corporate 1 GB",
                Platform = "Linux",
                DiskSpace = "1 GB",
                DataTransfer = "10 GB",
                EmailAccounts = "5 Accounts",
                PriceMonthlyInr = 250,
                PriceMonthlyUsd = 3.25m,
                IsPopular = false,
                Tagline = "Ideal for single-page corporate sites, lightweight web apps, and low-traffic business portals.",
                Highlights = new List<string>
                {
                    "1 GB Mirrored (RAID 1) NVMe Storage",
                    "10 GB High-Speed Monthly Bandwidth",
                    "5 Business Email Accounts (POP3/IMAP/SMTP)",
                    "Single Domain Hosting",
                    "cPanel Control Panel Included",
                    "Unlimited MySQL Databases & FTP Accounts",
                    "Automated Failover Across Dedicated Cloud Nodes",
                    "ClamAV Virus & Proactive Spam Filtering",
                    "Free DNS Management & Domain Forwarding",
                    "PHP 8.x, Python, Perl, Node.js Support",
                    "30-Day Money-Back Guarantee",
                    "24x7x365 Priority Support"
                },
                ControlPanel = "cPanel",
                Databases = "Unlimited MySQL",
                UptimeSla = "99.99%",
                DedicatedHardware = "Pooled Dedicated Hardware, Never Shared",
                BackupSchedule = "Automated Backups Every 5 Days",
                SupportLevel = "24x7x365 Support via Phone, Ticket & Chat"
            },
            new CloudPlan
            {
                Id = "linux-20gb",
                Name = "Linux Corporate 20 GB",
                Platform = "Linux",
                DiskSpace = "20 GB",
                DataTransfer = "200 GB",
                EmailAccounts = "50 Accounts",
                PriceMonthlyInr = 500,
                PriceMonthlyUsd = 6.50m,
                IsPopular = true,
                Tagline = "Most popular for growing business websites, busy e-commerce stores, and high-engagement digital agency portals.",
                Highlights = new List<string>
                {
                    "20 GB Mirrored (RAID 1) NVMe Storage",
                    "200 GB High-Speed Monthly Bandwidth",
                    "50 Business Email Accounts (Webmail & Mobile Ready)",
                    "Single Domain Hosting with Subdomain Support",
                    "cPanel Control Panel with Full Metrics",
                    "Unlimited MySQL Databases & Fast SSD I/O",
                    "Dedicated Compute Allocation (Zero Throttling)",
                    "Instant Automatic Failover to Healthy Hardware",
                    "ClamAV Protection, IP Blocker & Hotlink Defense",
                    "E-commerce Ready with Free Private SSL Setup",
                    "Free Zero-Downtime Migration Assistance",
                    "30-Day Money-Back Guarantee & 24x7 Support"
                },
                ControlPanel = "cPanel",
                Databases = "Unlimited MySQL",
                UptimeSla = "99.99%",
                DedicatedHardware = "Pooled Dedicated Hardware, Never Shared",
                BackupSchedule = "Automated Backups Every 5 Days",
                SupportLevel = "24x7x365 Support via Phone, Ticket & Chat"
            },
            new CloudPlan
            {
                Id = "linux-unlimited",
                Name = "Linux Corporate Unlimited",
                Platform = "Linux",
                DiskSpace = "Unlimited",
                DataTransfer = "Unlimited",
                EmailAccounts = "Unlimited",
                PriceMonthlyInr = 2500,
                PriceMonthlyUsd = 32.50m,
                IsPopular = false,
                Tagline = "Maximum power and unlimited headroom for heavy enterprise workloads, intense media traffic, and mission-critical databases.",
                Highlights = new List<string>
                {
                    "Unlimited High-Speed Mirrored NVMe Storage",
                    "Unlimited Unmetered Data Transfer",
                    "Unlimited Corporate Email Accounts",
                    "Single Domain Enterprise Architecture",
                    "cPanel Control Panel with Advanced Dev Utilities",
                    "Unlimited MySQL Databases with Dedicated Buffer Pool",
                    "Dedicated IP Address Included",
                    "Multi-Node High Availability Automatic Failover",
                    "Enterprise Security: ClamAV, Cron Jobs, SSH & SFTP",
                    "Priority 24x7 Direct Phone & Senior Engineer Support",
                    "Free White-Glove Migration Assistance",
                    "30-Day Full Money-Back Guarantee"
                },
                ControlPanel = "cPanel",
                Databases = "Unlimited MySQL",
                UptimeSla = "99.999% SLA",
                DedicatedHardware = "Pooled Dedicated Hardware, Never Shared",
                BackupSchedule = "Automated Backups Every 5 Days",
                SupportLevel = "24x7x365 Priority Tier-3 Support"
            }
        };
    }

    public List<CloudPlan> GetWindowsPlans()
    {
        return new List<CloudPlan>
        {
            new CloudPlan
            {
                Id = "win-1gb",
                Name = "Windows Corporate 1 GB",
                Platform = "Windows",
                DiskSpace = "1 GB",
                DataTransfer = "10 GB",
                EmailAccounts = "5 Accounts",
                PriceMonthlyInr = 250,
                PriceMonthlyUsd = 3.25m,
                IsPopular = false,
                Tagline = "Engineered for small corporate websites, internal tools, and Microsoft .NET web applications.",
                Highlights = new List<string>
                {
                    "1 GB Mirrored (RAID 1) Storage on Windows Server",
                    "10 GB High-Speed Monthly Bandwidth",
                    "5 Corporate Email Accounts (POP3/IMAP/Webmail)",
                    "Single Domain Windows Hosting",
                    "Plesk / WebSitePanel Control Panel",
                    "Unlimited MySQL & MSSQL Database Support",
                    "Dedicated Hardware Isolated Compute Pool",
                    "Automatic Failover Architecture",
                    "Full ASP.NET Core, .NET 10/8/6 & Classic ASP Support",
                    "Dedicated Application Pool for Total Isolation",
                    "30-Day Money-Back Guarantee",
                    "24x7x365 Priority Technical Support"
                },
                ControlPanel = "Plesk / Web Control Panel",
                Databases = "Unlimited MySQL & MSSQL",
                UptimeSla = "99.999% SLA",
                DedicatedHardware = "Dedicated Hardware, Never Shared",
                BackupSchedule = "Automated Backups Every 5 Days",
                SupportLevel = "24x7x365 Support via Phone, Ticket & Chat"
            },
            new CloudPlan
            {
                Id = "win-20gb",
                Name = "Windows Corporate 20 GB",
                Platform = "Windows",
                DiskSpace = "20 GB",
                DataTransfer = "200 GB",
                EmailAccounts = "50 Accounts",
                PriceMonthlyInr = 500,
                PriceMonthlyUsd = 6.50m,
                IsPopular = true,
                Tagline = "The standard for mid-sized enterprise applications, SQL Server portals, and corporate multi-tier web apps.",
                Highlights = new List<string>
                {
                    "20 GB Mirrored (RAID 1) Storage on Windows Server",
                    "200 GB High-Speed Monthly Bandwidth",
                    "50 Corporate Email Accounts with Exchange ActiveSync",
                    "Single Domain Enterprise Windows Hosting",
                    "Feature-Rich Plesk Control Panel with IIS Manager",
                    "Unlimited MySQL & MSSQL Databases",
                    "Dedicated RAM & vCPU Allocation",
                    "Instant Hardware Failover Protection",
                    "Anti-Spam & Proactive Antivirus Defense",
                    "Free SSL Certificate Setup Assistance",
                    "Free White-Glove Migration Assistance",
                    "30-Day Money-Back Guarantee & 24x7 Support"
                },
                ControlPanel = "Plesk / Web Control Panel",
                Databases = "Unlimited MySQL & MSSQL",
                UptimeSla = "99.999% SLA",
                DedicatedHardware = "Dedicated Hardware, Never Shared",
                BackupSchedule = "Automated Backups Every 5 Days",
                SupportLevel = "24x7x365 Support via Phone, Ticket & Chat"
            },
            new CloudPlan
            {
                Id = "win-unlimited",
                Name = "Windows Corporate Unlimited",
                Platform = "Windows",
                DiskSpace = "Unlimited",
                DataTransfer = "Unlimited",
                EmailAccounts = "Unlimited",
                PriceMonthlyInr = 2500,
                PriceMonthlyUsd = 32.50m,
                IsPopular = false,
                Tagline = "Unrestricted power for mission-critical enterprise systems, heavy SQL Server databases, and enterprise ERP/CRM web applications.",
                Highlights = new List<string>
                {
                    "Unlimited High-Speed Mirrored Windows Storage",
                    "Unlimited Unmetered Data Transfer",
                    "Unlimited Corporate Email Accounts",
                    "Single Domain High-Capacity Windows Architecture",
                    "Dedicated IP Address Included",
                    "Unlimited MySQL & High-Performance MSSQL Support",
                    "Dedicated Hardware Slice on Enterprise Intel Xeon / AMD Nodes",
                    "Instant Automatic Failover & High Availability",
                    "Full Administrative Control & Isolated IIS AppPool",
                    "Free Migration Assistance for .NET Apps & Databases",
                    "Direct Senior Windows Systems Engineer Support",
                    "30-Day Money-Back Guarantee & 99.999% SLA"
                },
                ControlPanel = "Plesk / Web Control Panel",
                Databases = "Unlimited MySQL & MSSQL",
                UptimeSla = "99.999% SLA",
                DedicatedHardware = "Dedicated Hardware, Never Shared",
                BackupSchedule = "Automated Backups Every 5 Days",
                SupportLevel = "24x7x365 Priority Tier-3 Support"
            }
        };
    }

    public List<FaqItem> GetFaqs()
    {
        return new List<FaqItem>
        {
            new FaqItem
            {
                Id = "faq-1",
                Category = "General",
                Question = "What is a cloud server?",
                Answer = "A cloud server is a high-performance virtual server that operates on top of a cluster of interconnected physical machines rather than relying on a single physical box. By pooling hardware resources, cloud servers provide instant elastic scaling, exceptional fault tolerance against hardware failures, and dedicated CPU and RAM that are never throttled by neighboring tenants."
            },
            new FaqItem
            {
                Id = "faq-2",
                Category = "General",
                Question = "How is a cloud server different from a VPS?",
                Answer = "While both traditional VPS and cloud servers offer dedicated resource slices and root/administrative control, a standard VPS is hosted on a single physical machine. If that physical server suffers a motherboard or drive failure, your VPS goes offline. SuperCloudServer cloud servers are distributed across pooled dedicated hardware with automatic failover—if a host node hiccups, your server instantly shifts to a healthy node without disruption, giving you superior uptime and seamless resource scaling."
            },
            new FaqItem
            {
                Id = "faq-3",
                Category = "Plans & Billing",
                Question = "Can I upgrade my plan later?",
                Answer = "Absolutely! You can instantly scale your CPU, RAM, or storage directly from your dashboard whenever your traffic or business needs grow. Upgrades take effect within moments with zero rebuild and no lengthy downtime. If you require a custom or hybrid architecture down the line, our cloud architects can assist you smoothly."
            },
            new FaqItem
            {
                Id = "faq-4",
                Category = "Technical",
                Question = "How quickly will my server be ready?",
                Answer = "Our cloud deployment pipeline is fully automated. In most cases, your server is provisioned and your control panel credentials are sent to your registered email address within 5 to 15 minutes of payment confirmation."
            },
            new FaqItem
            {
                Id = "faq-5",
                Category = "Security & Support",
                Question = "Do you offer backups?",
                Answer = "Yes. In addition to our continuous real-time mirrored (RAID 1) disk redundancy that protects your data against drive failures, automated snapshots and backups run every 5 days. You can also generate on-demand full cPanel/Plesk backups or download them locally at any time via your control panel."
            },
            new FaqItem
            {
                Id = "faq-6",
                Category = "Security & Support",
                Question = "Will you help me move my website (free migration)?",
                Answer = "Yes! Our specialized technical support team provides complimentary white-glove migration assistance. We will transfer your website files, databases, configurations, and corporate email accounts from your previous hosting provider to SuperCloudServer with zero data loss and minimal to zero downtime."
            },
            new FaqItem
            {
                Id = "faq-7",
                Category = "Technical",
                Question = "Which operating systems can I use?",
                Answer = "We provide both Linux and Windows cloud hosting environments. Linux Cloud Servers are ideal for PHP, WordPress, Laravel, Python, Perl, Node.js, and Ruby on Rails. Windows Cloud Servers are purpose-built for Microsoft ecosystems, including ASP.NET Core, .NET Framework, IIS, MSSQL databases, and corporate Windows applications."
            },
            new FaqItem
            {
                Id = "faq-8",
                Category = "Plans & Billing",
                Question = "Is there a refund policy?",
                Answer = "Yes, every SuperCloudServer cloud plan is protected by an unconditional 30-day money-back guarantee. If you are not completely satisfied with our performance or service within the first 30 days, we will issue a prompt refund (excluding third-party domain registration fees, which remain your property)."
            },
            new FaqItem
            {
                Id = "faq-9",
                Category = "Plans & Billing",
                Question = "How can I pay?",
                Answer = "We accept all major domestic and international payment options, including UPI (Google Pay, PhonePe, Paytm), RuPay, Visa, MasterCard, American Express, Net Banking across all Indian banks, digital wallets, and NEFT/RTGS bank transfers. Transparent GST tax invoices are automatically generated for all purchases so business customers can claim input tax credits."
            },
            new FaqItem
            {
                Id = "faq-10",
                Category = "Plans & Billing",
                Question = "What happens at renewal?",
                Answer = "We believe in transparent, honest pricing with no hidden surprises. Your plan renews at the exact rate clearly shown on your plan card. We send friendly automated reminders 30 days, 14 days, and 3 days before any renewal due date, allowing you full flexibility to upgrade, switch billing cycles, or cancel without friction."
            },
            new FaqItem
            {
                Id = "faq-11",
                Category = "Security & Support",
                Question = "Is my server protected from viruses and spam?",
                Answer = "Yes! Every cloud server is equipped with automated ClamAV antivirus scanning, comprehensive anti-spam email filters, and account-level firewall rules. You also benefit from IP blocking tools, hotlink protection, and password-protected directory controls to shield your applications from malicious bots."
            },
            new FaqItem
            {
                Id = "faq-12",
                Category = "Technical",
                Question = "Is email included?",
                Answer = "Yes, enterprise business email hosting is fully integrated into every plan. Depending on your chosen tier, you receive 5, 50, or unlimited accounts with full POP3, IMAP, and SMTP support, modern webmail access, auto-responders, email forwarders, and spam protection."
            },
            new FaqItem
            {
                Id = "faq-13",
                Category = "Technical",
                Question = "Do you offer SSH access?",
                Answer = "Yes! For developers and system administrators requiring command-line control, secure shell (SSH) access and SFTP credentials can be enabled on request for your cloud environment, giving you the administrative tools required to manage your deployments and build scripts."
            },
            new FaqItem
            {
                Id = "faq-14",
                Category = "General",
                Question = "Can I resell my cloud server space?",
                Answer = "These single-domain corporate cloud plans are engineered for dedicated business and agency workloads. While you can host client sub-domains and manage multiple client databases under your single domain, if you are looking to create independent cPanel accounts and billing for separate clients, our dedicated Reseller Cloud Hosting plans are designed specifically for that purpose."
            }
        };
    }

    public SubmissionResultViewModel SubmitLead(GetStartedViewModel model)
    {
        Leads.Add(model);

        string refCode = $"SCS-{DateTime.UtcNow:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}";
        string firstName = string.IsNullOrWhiteSpace(model.FullName) ? "Valued Customer" : model.FullName.Split(' ')[0];

        return new SubmissionResultViewModel
        {
            Success = true,
            ReferenceNumber = refCode,
            Message = $"Thank you, {firstName}. We've received your request for the {model.Platform} {model.Plan} plan and our cloud engineering team will contact you shortly.",
            FullName = model.FullName,
            Email = model.Email,
            Phone = model.Phone,
            Platform = model.Platform,
            Plan = model.Plan,
            SubmittedAt = DateTime.UtcNow
        };
    }
}

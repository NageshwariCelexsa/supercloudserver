# SuperCloudServer.com - Enterprise Cloud Hosting Website

A modern, high-performance website for **SuperCloudServer** built with **ASP.NET Core MVC (.NET 10)** based on the official copy and specifications from Celexsa Technologies.

---

## 🚀 Key Highlights & Architectural Features

1. **Brand Identity & SEO Optimization**:
   - Meta title: `Windows & Linux Cloud Server Hosting in India | SuperCloudServer`
   - Target keywords: `cloud server hosting, windows cloud hosting, linux cloud hosting, cloud server hosting providers India`
   - Full OpenGraph metadata for social sharing.
   - 24x7 Sales hotline integration: `+91 7401 6666 33`.

2. **15-Section Comprehensive Landing Page**:
   - **Hero Section**: "Cloud Servers That Grow When You Do", trust badges (30-day money-back guarantee, 24x7 support, dedicated hardware, 99.99% SLA), and real-time interactive server node health visualizer.
   - **Why Choose SuperCloudServer**: 5 key pillars (Performance without the wait, Resources that are truly yours, Scale in a few clicks, Built-in protection, Real people any hour) plus automatic failover.
   - **Plans & Pricing**:
     - **Linux Corporate Single-Domain**:
       - 1 GB NVMe / 10 GB Bandwidth / 5 Emails – ₹250 / month ($3.25)
       - 20 GB NVMe / 200 GB Bandwidth / 50 Emails – ₹500 / month ($6.50)
       - Unlimited NVMe / Unlimited Bandwidth / Unlimited Emails – ₹2,500 / month ($32.50)
     - **Windows Corporate Single-Domain**:
       - 1 GB Disk / 10 GB Bandwidth / 5 Emails – ₹250 / month ($3.25)
       - 20 GB Disk / 200 GB Bandwidth / 50 Emails – ₹500 / month ($6.50)
       - Unlimited Disk / Unlimited Bandwidth / Unlimited Emails – ₹2,500 / month ($32.50)
     - Interactive Platform Switcher (Linux vs Windows).
     - Currency toggle (₹ INR / $ USD) and Billing cycle toggle (Monthly / Annual with 15% discount).
     - "Configure & Deploy" click action that smoothly pre-fills the form and scrolls to it.
   - **Interactive Cloud Resource Calculator**: Sliders for vCPU, RAM, and NVMe disk with live dynamic monthly estimation and custom quote generation.
   - **What Is Included With Every Cloud Server**: 12-item grid (pooled dedicated hardware, RAID 1 storage, cPanel/Plesk, free DNS, unlimited MySQL, email hosting, ClamAV & anti-spam, security hardening, multi-language support, dedicated IP, instant scaling, free migration).
   - **Level of Management**: Self-Managed vs. Fully Managed comparison cards.
   - **Who Is It For (Use Cases)**: Online stores, agencies, startups, SaaS owners, databases/CRMs, and growing websites.
   - **Platform Choice Guide**: Side-by-side Linux vs. Windows comparison.
   - **3-Step Deployment**: Choose Plan -> Configure -> Go Live.
   - **Cloud Server vs. Shared Hosting vs. VPS**: Full technical comparison table.
   - **Security and Reliability**: RAID 1 mirrored architecture, automated backups every 5 days, ClamAV, and 99.99% uptime SLA.
   - **Support & Free Migration**: 4-step seamless migration roadmap and 24x7 direct phone support.
   - **Interactive Get Started Form**: Model-bound form with validation, AJAX submission, tracking reference generation (`SCS-YYYYMMDD-XXXX`), and fallbacks.
   - **14 FAQs Accordion**: Searchable in real-time with category filters.
   - **Closing Call to Action & Footer**: Comprehensive enterprise footer with links, Celexsa brand attribution, and trust certifications.

---

## 📁 Project Structure

```text
supercloudserver/
├── Controllers/
│   └── HomeController.cs          # Index, SubmitRequest (Form/AJAX), Confirmation, Plans, Compare, Contact, Privacy
├── Models/
│   ├── CloudPlan.cs               # Plan properties, pricing, specs
│   ├── FaqItem.cs                 # FAQ questions, answers, categories
│   ├── GetStartedViewModel.cs     # Form fields with DataAnnotations validation
│   ├── HomeViewModel.cs           # Composite view model
│   └── SubmissionResultViewModel.cs# Confirmation & tracking reference
├── Services/
│   ├── ICloudDataService.cs       # Data access contract
│   └── CloudDataService.cs        # Linux/Windows plan data, FAQs, lead repository
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml           # Master 15-section landing page
│   │   ├── Confirmation.cshtml    # Request success & receipt screen
│   │   ├── Plans.cshtml           # Dedicated plans view
│   │   ├── Compare.cshtml         # Dedicated Cloud vs VPS comparison
│   │   ├── Contact.cshtml         # Dedicated inquiry view
│   │   └── Privacy.cshtml         # Privacy policy
│   └── Shared/
│       ├── _Layout.cshtml         # Master layout with top bar, navbar, footer, SEO
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css               # Modern design system (Plus Jakarta Sans, cards, gradients)
│   └── js/
│       └── site.js                # Currency & cycle toggles, calculator, FAQ search, AJAX submit
├── Program.cs                     # DI configuration, Data Protection, Routing
└── supercloudserver.csproj        # .NET 10 SDK Web Project
```

---

## 🛠️ How to Run

1. Open PowerShell or Terminal in the project root:
   ```powershell
   cd "D:\Celexsa\Cloud Server\supercloudserver"
   ```

2. Build the project:
   ```powershell
   dotnet build
   ```

3. Launch the web application:
   ```powershell
   dotnet run
   ```

4. Open your browser and navigate to:
   ```text
   http://localhost:5182
   ```

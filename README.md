# Takyon Networks Limited — Public Corporate Website

**Client:** Takyon Networks Limited  
**Status:** Initial Frontend Phase Complete  
**Framework:** ASP.NET Core Razor Pages (.NET 10.0)  
**UI Stack:** Bootstrap 5.3, Vanilla JavaScript, Semantic HTML5, Takyon Design System (CSS custom properties)  
**Data Architecture:** Strongly typed C# ViewModels & Mock Content Provider (`ITakyonContentProvider`) via Dependency Injection  

---

## 1. Project Overview

This repository contains the public-facing corporate website for **Takyon Networks Limited**, a BSE-listed IT system integrator and infrastructure solutions provider founded in 2009 and headquartered in Lucknow, Uttar Pradesh.

The initial implementation focuses strictly on the public-facing frontend presentation layer. In accordance with architectural boundaries:
- **No database, Entity Framework Core, or database migrations** have been introduced.
- **No server-side contact processing, email dispatch, or newsletter storage** is implemented.
- **No authentication, password management, or CMS dashboards** are included.
- All repeatable content is separated into strongly typed ViewModels and supplied via a centralized mock content provider (`MockTakyonContentProvider`), allowing future EF Core and application services to replace the data source without rewriting the UI views.

---

## 2. Confirmed Public Pages (9 Pages)

The website implements all 9 confirmed public routes:

| Route | Page | Purpose & Grounded Content |
|---|---|---|
| `/` | **Home** | Concise company overview, BSE & CMMI credentials, 6 Core Solutions highlights, 6 industry vertical previews, 6 notable project case studies, and OEM partner logos. |
| `/About` | **About Us** | Corporate narrative, verified history milestones (2009–2026), official mission, vision, 8 core values, and government empanelment credentials. |
| `/Leadership` | **Leadership** | Board of Directors and senior management: Manish Sharma (MD), Neeraj Kumar (CEO), Nikhil Buran (Director of Sales), Paresh Goyal (Executive Director), Rahul Patwa (CTO), Vivek Singh (CFO) with verified photos and bios. |
| `/Services` | **Services** | Primary presentation of the **6 Core IT Solutions** from the brochure, plus a dedicated section for **Specialized Categories** (SD-WAN, Drone-Enabled Solutions, Software) from the company profile. |
| `/Industries` | **Industries** | Cross-sector coverage across 12 verticals (Government, Railways, Defence, Education, Healthcare, BFSI, Power Utilities, Enterprise, Telecom, Manufacturing, Hospitality, Media). |
| `/Projects` | **Projects** | 9 verified notable project case studies from the A4 brochure (AIIMS Bibinagar, RDSO Telecom, Indian Army Eastern Command, UPSWAN 2.0, Bihar SWAN, MPPGCL 19 Power Plants, HAL Lucknow, AIIMS Guwahati, NIC DDOS). |
| `/Clients` | **Clients** | 20 client organizations across government, defence, railways, healthcare, and education with portfolio disclosure notes. |
| `/Partners` | **Partners** | 28 primary global OEM partner logos (Dell, APC, Arista, AWS, Fortinet, Microsoft, etc.) and directory of 40+ technology alliances. |
| `/Contact` | **Contact** | Corporate office directory (Lucknow HQ, Delhi Regional, Kolkata Branch), interactive client-side validated form, and explicit prototype-only status notices. |

---

## 3. Source-of-Truth Decisions & Documented Discrepancies

In strict compliance with editorial and architectural instructions:
1. **Service Taxonomy:** The 6 Core IT Solutions established in the A4 Brochure (p.4) are preserved as the primary service pillars (`Enterprise Networking`, `Cyber Security`, `Data Center`, `Cloud Solutions`, `Security & Surveillance`, `AV and Collaboration Services`). The additional service domains from the Company Profile (`SD-WAN & WAN Solutions`, `Drone-Enabled Solutions`, and `Customized Software Solutions`) are modeled separately as specialized extensions, preserving all source categories without conflation or loss.
2. **Delhi Office Address:** The Company Profile (p.29) lists `911, 9th Floor, DLF Jasola Vihar, New Delhi 110025`, while the A4 Brochure (p.2 & p.8) lists `307, DLF Tower-B, Jasola District Center, New Delhi 110025`. Because this discrepancy is unresolved, the physical Delhi address is **withheld from public display** with an explicit transparent notice until confirmed by stakeholders.
3. **Lucknow HQ Phone:** The Company Profile (p.29) lists `(022) 665 6617` (Mumbai 022 STD code), while the Brochure (p.2 & p.8) lists `(0522) 665 6617` (Lucknow 0522 STD code). The correct Lucknow STD code `(0522) 665 6617` is used.
4. **Contact QR Generator:** Static QR codes on brochure page 8 are referenced, but dynamic QR code generation is deferred until the exact payload format (vCard vs verified URL) is formally specified by the client.
5. **Form Behavior:** Contact and newsletter forms execute client-side validation only. On valid submission, they display an honest demo alert confirming frontend validation passed and explicitly stating that no message was sent or stored.

---

## 4. Getting Started & Verification

### Prerequisites
- .NET 10.0 SDK (`10.0.400` or higher)

### Build the Application
```bash
dotnet build
```
*Expected result:* 0 Warnings, 0 Errors.

### Run the Application
```bash
dotnet run
```
Open `http://localhost:5000` or `https://localhost:5001` in any modern browser.

### Run Route Verification Test Suite
```bash
python test_routes.py
```
*Verification results:* 22/22 routes and assets verified (HTTP 200 and expected content strings).

---

## 5. Architecture & File Layout

```text
Takyon/
├── Takyon.csproj                          # ASP.NET Core 10 Web Application
├── Program.cs                             # Hosting, Static Files, DI Service Registration
├── README.md                              # Technical documentation
├── test_routes.py                         # Automated end-to-end route verification script
├── Content/
│   ├── Interfaces/
│   │   └── ITakyonContentProvider.cs      # Contract for content retrieval
│   └── Mock/
│       └── MockTakyonContentProvider.cs   # Source-grounded static data
├── Models/
│   └── ViewModels/
│       ├── CompanyOverviewViewModel.cs
│       ├── LeadershipMemberViewModel.cs
│       ├── SolutionItemViewModel.cs
│       ├── IndustryVerticalViewModel.cs
│       ├── ProjectCaseStudyViewModel.cs
│       ├── ClientLogoViewModel.cs
│       ├── PartnerLogoViewModel.cs
│       ├── OfficeContactViewModel.cs
│       └── ContactFormViewModel.cs
├── Pages/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Error.cshtml / .cs
│   ├── Index.cshtml / .cs                 # Home
│   ├── About/Index.cshtml / .cs           # About Us
│   ├── Leadership/Index.cshtml / .cs      # Leadership
│   ├── Services/Index.cshtml / .cs        # Services
│   ├── Industries/Index.cshtml / .cs      # Industries
│   ├── Projects/Index.cshtml / .cs        # Projects
│   ├── Clients/Index.cshtml / .cs         # Clients
│   ├── Partners/Index.cshtml / .cs        # Partners
│   ├── Contact/Index.cshtml / .cs         # Contact
│   └── Shared/
│       ├── _Layout.cshtml                 # Master responsive layout
│       ├── _SiteHeader.cshtml             # Navigation & top utility bar
│       ├── _SiteFooter.cshtml             # Corporate footer with badges & links
│       ├── _HeroSection.cshtml            # Reusable page banner
│       └── _ValidationScriptsPartial.cshtml
└── wwwroot/
    ├── css/
    │   └── site.css                       # Brand tokens, responsive typography, cards
    ├── js/
    │   ├── site.js                        # Navigation interactions
    │   └── forms.js                       # Client-side validation & prototype notices
    ├── lib/                               # Bootstrap 5 & jQuery validation
    └── images/
        ├── brand/                         # Takyon logo & corporate building
        ├── leadership/                    # 6 executive portraits
        ├── projects/                      # 9 notable project photographs
        ├── clients/                       # 20 portfolio client logos
        ├── partners/                      # 28 OEM partner logos
        └── badges/                        # BSE & CMMI Level 3 badges
```

---

## 6. Accessibility & Responsive Verification

- **Responsive Viewports Tested:** Verified layouts across 320px (compact mobile), 375px (iPhone standard), 768px (iPad portrait), 1024px (tablet landscape / desktop), and 1440px (wide desktop).
- **No Unintended Horizontal Overflow:** All grid containers utilize Bootstrap's flexbox rows and fluid constraints.
- **Focus Indicators:** Defined `*:focus-visible` with 3px high-contrast outline (`#078BC5`).
- **Contrast Ratios:** Primary typography exceeds WCAG AA and AAA requirements (Navy on White: 11.5:1; Dark Body on White: 10.7:1; Blue on White: 4.6:1).
- **Semantics:** Landmark elements (`<nav>`, `<main role="main">`, `<footer role="contentinfo">`, `<section>`) and strict logical heading hierarchy (`<h1>` to `<h4>`) are applied across all views.
- **Reduced Motion:** Included `@media (prefers-reduced-motion: reduce)` resets in `site.css`.


# Takyon — Product Requirements Document (PRD)

## 1. Document Information

- **Project:** Takyon Networks Limited Website
- **Document:** Product Requirements Document
- **Status:** Planning baseline
- **Frontend:** ASP.NET Core Razor Pages on .NET 10 (Single-domain monolithic application)
- **Initial data source:** Static/mock data via centralized provider (`MockTakyonContentProvider`)
- **Backend:** Deferred to a later phase (EF Core provider replacement architecture)

### Approved Source Documents

1. `company profile updated(1).pdf` (29-page company profile)
2. `TAKYON BROCHURE A4 Size Colour Change(1).pdf` (8-page A4 brochure)

The 29-page company profile is the primary reference for company branding, leadership titles, company information, and contact details. The 8-page A4 brochure is the supporting reference for the six core brochure solutions, documented projects, and brochure-specific credentials or claims. Where documents disagree, discrepancies are explicitly documented and exceptions preserved rather than silently overwritten.

## 2. Product Overview

Takyon is a public-facing corporate website for Takyon Networks Limited.

The website will present the company's identity, services, industries, leadership, projects, clients, technology partners, and contact information through a responsive and professional user interface.

The first implementation phase will focus on the public-facing frontend. All repeatable content will use strongly typed C# ViewModels and static/mock data providers.

A lightweight content management system (CMS) is planned for a later phase. It will support managing business content, but it will not be implemented during the initial frontend phase.

## 3. Problem Statement

The company information currently exists in PDF documents. A responsive website will make this information easier to navigate and consume across desktop, tablet, and mobile devices.

The website should help prospective customers and business partners understand Takyon's capabilities, review its project experience, explore its technology partnerships, and find appropriate contact channels.

The initial objective is to validate the information architecture, visual design, and public user experience before introducing backend complexity.

## 4. Product Goals

1. Build a professional website aligned with Takyon's existing brand identity.
2. Present company information using clear navigation and consistent layouts.
3. Explain the company's solution areas and industry coverage.
4. Showcase source-supported projects, clients, credentials, and OEM partnerships.
5. Provide responsive layouts for mobile, tablet, and desktop.
6. Use reusable Razor components and strongly typed ViewModels.
7. Use static/mock data without requiring a database.
8. Implement accessible client-side form validation.
9. Keep the architecture ready for future application services, EF Core, database persistence, and CMS integration.
10. Avoid inventing business information not supported by the approved documents.

## 5. Non-Goals for the Initial Phase

The following are explicitly outside the initial implementation scope:

- Database creation or persistence.
- Entity Framework Core integration.
- Server-side form processing.
- Email dispatch.
- Newsletter subscription storage.
- ASP.NET Core Identity.
- Login, registration, and password management.
- Admin dashboard and CMS screens.
- Career application processing.
- Blog publishing workflows.
- Investor disclosure upload and management.
- Production deployment and operational monitoring.

These capabilities may be implemented in later phases after requirements are approved.

## 6. Source-of-Truth Rules

The project enforces an explicit source hierarchy to govern content accuracy, design fidelity, and architectural alignment:

1. **Primary Reference:** The 29-page company profile (`company profile updated(1).pdf`) is the primary reference for company branding, leadership titles, company background, and corporate contact details.
2. **Supporting Reference:** The 8-page A4 brochure (`TAKYON BROCHURE A4 Size Colour Change(1).pdf`) is the supporting reference for the six core brochure solutions, documented project case studies, and brochure-specific credentials or claims.
3. **Preserve Discrepancies:** Where the source documents disagree, preserve the discrepancy instead of silently rewriting or guessing the source. All unresolved differences must be explicitly documented and reported for stakeholder review.
4. **Inline Code Documentation:** Where implementation code or mock data reflects a source discrepancy, add concise inline code comments identifying the source conflict, rationale, and publication status.
5. **No Invention of Facts:** Do not invent company statistics, leadership biographies, client relationships, certifications, or project outcomes. Unverified facts must not be described as confirmed.
6. **Specific Contact & Address Discrepancy Rules:**
   - **Lucknow HQ Phone:** The company profile (p.29) lists `(022) 665 6617`, whereas the brochure (p.2 & p.8) lists `(0522) 665 6617`. The company profile serves as the general source of truth, but this specific exception is documented explicitly: `022` is a Mumbai STD code while `0522` is Lucknow's STD code. In the existing implementation (`MockTakyonContentProvider.cs`), `(0522) 665 6617` is provisionally used as the implementation value with explanatory code comments, while the discrepancy is documented for formal client confirmation.
   - **Delhi Office Address:** The company profile (p.29) lists `911, 9th Floor, DLF Jasola Vihar, New Delhi 110025`, while the brochure (p.2 & p.8) lists `307, DLF Tower-B, Jasola District Center, New Delhi 110025`. In accordance with strict source-of-truth instructions, this address is not silently reconciled; physical address display is withheld from publication with a transparent notice until confirmed by stakeholders.
   - **Contact QR Generator:** Dynamic QR code generation is withheld until the official payload specification (vCard vs verified company URL) is confirmed.
7. **Local Asset Architecture:** All approved images and logos must be stored locally under `wwwroot/images/` organized into six subdirectories (`brand/`, `leadership/`, `projects/`, `clients/`, `partners/`, `badges/`). Remote image hotlinking is strictly prohibited.
8. **Open Questions:** Record unsupported or unclear requirements under Open Questions.

## 7. User Roles and Personas

### 7.1 Prospective Customer

**Goal:** Understand Takyon's capabilities and determine whether its services match their business requirements.

**Needs:**
- Company overview.
- Solution descriptions.
- Industry coverage.
- Project experience.
- Contact information.

### 7.2 Government or Enterprise Stakeholder

**Goal:** Evaluate company credentials, relevant project experience, and service capabilities.

**Needs:**
- Source-supported credentials.
- Relevant project descriptions.
- Industry information.
- Approved client and partner information.

### 7.3 Technology Partner

**Goal:** Understand Takyon's technology ecosystem and business capabilities.

**Needs:**
- OEM partner directory.
- Company overview.
- Service information.
- Contact routes.

### 7.4 Job Seeker

**Goal:** Find career opportunities and understand the company.

A public Careers page is not included in the confirmed initial page inventory. Its scope requires clarification.

### 7.5 Internal Content Administrator — Future Phase

**Goal:** Manage company content through a secure admin CMS.

The future CMS is expected to manage:

1. Inbound inquiries and leads.
2. Blog articles and technical knowledge-base content.
3. Career postings and job applications.
4. Portfolio projects, case studies, clients, and partner logos.
5. Investor disclosures and financial updates.

Authentication, persistence, and CMS screens are deferred.

## 8. Feature Priorities

| Feature | Priority | Initial treatment |
|---|---|---|
| Responsive site layout | Must | Implement |
| Home page | Must | Implement |
| About Us page | Must | Implement |
| Leadership page | Must | Implement |
| Services page | Must | Implement |
| Industries page | Must | Implement |
| Projects page | Must | Implement |
| Clients page | Must | Implement |
| Partners page | Must | Implement |
| Contact page | Must | Implement |
| Strongly typed ViewModels | Must | Implement |
| Static/mock data providers | Must | Implement |
| Responsive Bootstrap 5 components | Must | Implement |
| Contact form validation | Must | Client-side only |
| Newsletter form UI | Should | Client-side only |
| Contact QR generator | Should | Pending payload confirmation |
| Blog and Knowledge Base CMS | Future | Plan only |
| Careers CMS | Future | Plan only |
| Lead management CMS | Future | Plan only |
| Investor disclosure CMS | Future | Plan only |
| Database persistence | Deferred | Do not implement |
| Authentication and authorization | Deferred | Do not implement |

## 9. Functional Requirements

### FR-01: Home Page

The Home page must provide:

- Company introduction.
- Primary navigation.
- Approved company credibility indicators.
- Solution highlights.
- Industry highlights.
- Selected project highlights.
- Technology partner highlights.
- Contact calls to action.

All company claims must be supported by approved source content.

### FR-02: About Us

The page must present source-supported company information, mission, vision, values, history, and presence where available.

### FR-03: Leadership

The page must present approved leadership names, titles, portraits, and biographies where supported.

Conflicting titles or missing biographies must not be guessed.

### FR-04: Service Taxonomy & Services Page

The content model and mock content provider support all **8 service categories** represented in the approved 29-page company profile:
1. Enterprise Networking
2. Cyber Security
3. Data Center Solutions
4. Cloud Solutions (Cloud & Managed Services)
5. Security & Surveillance
6. AV & Collaboration Services (AV & Collaboration Solutions)
7. SD-WAN & WAN Solutions
8. Drone-Enabled Solutions (Drone-Enabled Monitoring)

Service display and taxonomy rules:
- Each service model has an `IsFeatured` boolean property.
- Exactly the **6 core solutions identified in the brochure** are marked `IsFeatured = true`:
  1. Enterprise Networking
  2. Cyber Security
  3. Data Center Solutions
  4. Cloud Solutions
  5. Security & Surveillance
  6. AV & Collaboration Services
- The remaining 2 profile categories (`SD-WAN & WAN Solutions` and `Drone-Enabled Solutions`) remain available in the complete service catalog with `IsFeatured = false`.
- The Home page displays exactly the 6 featured solutions selected via `IsFeatured = true`.
- The Services page displays the full catalog of all 8 categories (the 6 core brochure solutions plus the 2 specialized profile categories).
- Razor views and markup must not duplicate or manually redefine the service catalog; they consume data supplied through PageModels and strongly typed ViewModels from `ITakyonContentProvider`.
- Do not discard profile content or invent new service categories. Preserves all source terminology and descriptions.

### FR-05: Industries

The page must present the industry sectors identified in the approved profile.

Descriptions must be grounded in the source material.

### FR-06: Projects

The page must present notable projects using the brochure's project names, client information, and scopes.

The interface must not fabricate project metrics or results.

### FR-07: Clients

The page must present approved client names and logos.

The display must not imply a current contract or endorsement beyond what the source supports.

### FR-08: Partners

The page must present approved OEM and technology partner names or logos.

Logos should use consistent sizing and accessible text alternatives.

### FR-09: Contact

The page must display approved contact details and provide a contact form interface.

Client-side validation must check required fields and email format.

A successful demo submission must explicitly state that the message was not sent or stored by a backend.

### FR-10: Newsletter

The newsletter form must provide basic email validation.

No subscription may be described as completed or persisted because backend processing is not included.

### FR-11: Future CMS Compatibility

Repeatable content must be separated from Razor markup so mock providers can later be replaced by real services.

## 10. User Stories and Acceptance Criteria

### US-01: Explore the Company

As a prospective customer, I want to understand Takyon's business and capabilities.

**Acceptance criteria:**
- The Home page identifies the company.
- Navigation to the confirmed public pages works.
- Company information comes from approved source material.
- The layout adapts to supported screen sizes.

### US-02: Understand Company Background

As a visitor, I want to learn about the company's history and values.

**Acceptance criteria:**
- About Us content is organized into readable sections.
- Mission, vision, and values are source-supported.
- Missing facts are not fabricated.

### US-03: Explore Leadership

As a visitor, I want to learn about company leadership.

**Acceptance criteria:**
- Leadership cards use a consistent layout.
- Names and titles match approved source information.
- Missing portraits do not break the layout.

### US-04: Explore Solutions

As a visitor, I want to understand the available solution areas.

**Acceptance criteria:**
- Solution cards have consistent structure, layout, and typography.
- Exactly the 6 core featured solutions are displayed on the Home page via `IsFeatured = true`.
- The Services page displays all 8 profile service categories from the centralized content catalog.
- Each card displays source-grounded title, summary, sub-services, and technical highlights.
- Views consume data through PageModels from `ITakyonContentProvider` without duplicated datasets in markup.

### US-05: Review Projects

As a stakeholder, I want to review relevant project experience.

**Acceptance criteria:**
- Project information matches the brochure.
- Client and scope information are displayed accurately.
- Unsupported outcomes are excluded.

### US-06: Contact Takyon

As a visitor, I want to contact the company.

**Acceptance criteria:**
- Approved contact details are visible.
- Required fields have labels and validation messages.
- Invalid input is clearly identified.
- Valid demo submission displays a message explaining that no backend delivery occurred.

### US-07: Subscribe to Newsletter

As a visitor, I want to enter my email address.

**Acceptance criteria:**
- Email format is validated.
- Validation feedback is accessible.
- The UI clearly identifies the form as a prototype.

### US-08: Maintainable Content

As a future developer, I want repeatable content separated from presentation.

**Acceptance criteria:**
- Razor views do not contain duplicated datasets.
- ViewModels represent page data.
- Mock providers supply repeated content.
- The future service integration path is documented.

## 11. Screen and Page Inventory

| Page | Purpose |
|---|---|
| Home | Company introduction, 6 featured solutions, and primary navigation |
| About Us | Company background, mission, vision, and values |
| Leadership | Leadership information |
| Services | Complete 8-category solution catalog and descriptions |
| Industries | Industry coverage |
| Projects | Notable projects and case studies |
| Clients | Approved client directory |
| Partners | OEM and technology partner directory |
| Contact | Contact details and form UI |

### Future or Unconfirmed Screens

| Screen | Status |
|---|---|
| Blog / Knowledge Base | Public page requirements unconfirmed |
| Careers | Public page requirements unconfirmed |
| Investor Disclosures | Public page requirements unconfirmed |
| Admin Dashboard | Future phase |
| Lead Management | Future phase |
| Article Management | Future phase |
| Career Management | Future phase |
| Project and Partner Management | Future phase |
| Investor Disclosure Management | Future phase |

## 12. Success Metrics

The initial phase will be evaluated using these criteria:

- All confirmed pages render and navigate correctly.
- Repeated content is supplied through typed ViewModels and mock providers.
- The layout works at mobile, tablet, and desktop widths.
- There is no unintended horizontal overflow.
- Forms provide clear client-side validation.
- Demo interactions do not claim to persist or send data.
- Internal links and local assets work.
- No known critical browser-console errors remain.
- Source content is checked for accuracy.

Performance and accessibility audit targets should be agreed before the final production release.

## 13. Risks

1. Conflicting information across the approved PDFs.
2. Missing or low-resolution original image and logo assets.
3. Unsupported client, project, or certification claims.
4. Unclear service taxonomy.
5. Prototype forms being mistaken for working backend services.
6. Scope expansion into CMS functionality before requirements are ready.
7. Unconfirmed contact details or QR payload.
8. Future privacy and security requirements for leads, applications, and investor documents.

## 14. Open Questions

1. **[Resolved — Service Taxonomy]** What are the official solution categories? — **Resolved:** The content model and mock content provider support all 8 service categories from the approved 29-page company profile. Each service model includes an `IsFeatured` boolean property. Exactly the 6 core solutions identified in the brochure are marked `IsFeatured = true` and rendered on the Home page; the Services page renders the complete 8-category catalog (including the two non-featured categories, SD-WAN & WAN Solutions and Drone-Enabled Solutions).
2. Should Blog, Careers, and Investor Disclosures be public pages in the initial website?
3. What exact information should the Contact QR generator encode? (Dynamic generation withheld until URL or vCard payload is confirmed).
4. **[Resolved — Brochure Discrepancy Rule]** Which office addresses and phone numbers are approved for publication? — **Resolved:** The 29-page company profile is the primary reference, with discrepancies explicitly documented and exceptions preserved. For the Lucknow HQ phone, profile lists `(022) 665 6617` (Mumbai STD code typo) while the brochure lists `(0522) 665 6617` (Lucknow STD code); the implementation provisionally uses `(0522) 665 6617` with documented rationale, marked for client confirmation. For the Delhi office address, profile p.29 (`911, 9th Floor, DLF Jasola Vihar`) conflicts with brochure p.2/8 (`307, DLF Tower-B, Jasola District Center`); the physical address is withheld from publication with a transparent notice pending verification.
5. Which leadership titles and biographies are current?
6. **[Resolved — Local Asset Storage]** Are all client and OEM logos approved for website use? — **Resolved:** All approved images and logos must be stored locally under `wwwroot/images/` across six structured subdirectories (`brand/`, `leadership/`, `projects/`, `clients/`, `partners/`, `badges/`). Remote image hotlinking is prohibited. All 68 approved assets are verified in the repository.
7. Should all brochure projects be displayed, or only a selected subset?
8. What newsletter consent wording and privacy-policy destination should be used?
9. What is the approved source and publication process for investor disclosures?
10. What are the target hosting environment and deployment requirements? (.NET 10.0 ASP.NET Core Razor Pages baseline established).

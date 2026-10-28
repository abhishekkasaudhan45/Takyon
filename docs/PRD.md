
# Takyon — Product Requirements Document (PRD)

## 1. Document Information

- **Project:** Takyon Networks Limited Website
- **Document:** Product Requirements Document
- **Status:** Planning baseline
- **Frontend:** ASP.NET Core Razor Pages, C#, Bootstrap 5
- **Initial data source:** Static/mock data
- **Backend:** Deferred to a later phase

### Approved Source Documents

1. `company profile updated(1).pdf`
2. `TAKYON BROCHURE A4 Size Colour Change(1).pdf`

The updated company profile is the primary reference for branding and company information. The A4 brochure provides supporting project descriptions and company credentials.

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

1. Use the updated company profile for the primary visual identity and company content.
2. Use the A4 brochure for supplementary project descriptions and credentials.
3. Do not silently reconcile conflicting facts between the documents.
4. Do not invent company statistics, leadership biographies, client relationships, certifications, or project outcomes.
5. Verify office addresses, phone numbers, titles, and other potentially conflicting information before publication.
6. Use original logo and image assets where available and approved.
7. Record unsupported or unclear requirements under Open Questions.

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

### FR-04: Services

The page must present the approved solution categories using consistent reusable cards and descriptions.

The source documents show more service categories than the requested six. The official six-category taxonomy must be confirmed before finalizing the grouping.

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
- Solution cards have consistent structure.
- Each card has a title and description.
- The official solution taxonomy is confirmed before final approval.

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
| Home | Company introduction and primary navigation |
| About Us | Company background, mission, vision, and values |
| Leadership | Leadership information |
| Services | Solution categories and descriptions |
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

1. What are the official six top-level solution categories?
2. Should Blog, Careers, and Investor Disclosures be public pages in the initial website?
3. What exact information should the Contact QR generator encode?
4. Which office addresses and phone numbers are approved for publication?
5. Which leadership titles and biographies are current?
6. Are all client and OEM logos approved for website use?
7. Should all brochure projects be displayed, or only a selected subset?
8. What newsletter consent wording and privacy-policy destination should be used?
9. What is the approved source and publication process for investor disclosures?
10. What are the target .NET framework, hosting environment, and deployment requirements?

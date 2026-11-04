
# Takyon — Implementation Plan

## 1. Objective

Build a responsive public-facing website for Takyon Networks Limited using ASP.NET Core Razor Pages, C#, and Bootstrap 5.

The first release will use static/mock data and focus on UI/UX quality, accurate content, reusable components, and maintainable architecture.

Backend persistence, authentication, and CMS functionality will be implemented only in later approved phases.

## 2. Delivery Strategy

Work phase by phase.

Each phase must be verified before moving to the next. Resolve content questions before publishing uncertain information.

Do not build the entire system in one large operation.

## 3. Phase Overview

| Phase | Description | Estimated effort |
|---|---|---|
| Phase 0 | Requirements and project setup | 0.5–1 day |
| Phase 1 | Design system and shared layout | 1–2 days |
| Phase 2 | ViewModels, mock data, and public pages | 3–5 days |
| Phase 3 | Form interactions and UI polish | 1–2 days |
| Phase 4 | Testing and final frontend review | 1–2 days |
| Phase 5 | Backend and database integration | Separate estimate |
| Phase 6 | Admin CMS and security | Separate estimate |
| Phase 7 | Production deployment | Separate estimate |

These estimates are planning assumptions for a student project. Actual effort depends on the repository's condition and the availability of approved assets.

# Phase 0 — Requirements and Setup

## Tasks

- [x] Read `PRD.md`.
- [x] Read `DESIGN.md`.
- [x] Read `TRD.md`.
- [x] Read `IMPLEMENTATION_PLAN.md`.
- [x] Review the updated company profile (29-page primary reference).
- [x] Review the A4 brochure (8-page supporting reference).
- [x] Inspect the existing repository structure and root.
- [x] Inspect the Git working tree before modifying files.
- [x] Identify the current .NET SDK and target framework (.NET 10.0 / ASP.NET Core Razor Pages).
- [x] Verify local asset storage under `wwwroot/images/` (Verified: 68 total local image and logo assets exist across `brand/`, `leadership/`, `projects/`, `clients/`, `partners/`, and `badges/` with zero remote hotlinking).
- [x] Confirm the official solution taxonomy (Established: 8 service categories from the 29-page profile, exactly 6 featured solutions from the brochure, with `IsFeatured` controlling Home page selection).
- [x] Record discrepancies in leadership titles and contact details (Lucknow HQ phone, Delhi office address, contact QR code payload).
- [ ] Confirm the QR generator's intended payload (Dynamic generation withheld until payload specification is confirmed).
- [ ] Confirm the scope of future public pages (Blog, Careers, Investor Disclosures).
- [x] Establish a clean, buildable project baseline (`dotnet build` succeeds with 0 warnings, 0 errors).
- [x] Verify Bootstrap 5 availability.
- [x] Add or update README.md with setup instructions.

## Dependencies

None.

## Definition of Done

- [x] The repository structure is understood.
- [x] The existing project builds successfully, or baseline failures are documented.
- [x] The target framework is confirmed (.NET 10.0).
- [x] The source documents have been reviewed.
- [x] Unresolved requirements are documented.
- [x] No backend or database code has been introduced.

# Phase 1 — Design System and Shared Layout

## Tasks

### Branding

- [ ] Extract or locate approved logo assets.
- [ ] Review brand colors against the PDFs.
- [ ] Define CSS custom properties.
- [ ] Establish typography styles.
- [ ] Define spacing and container conventions.
- [ ] Define button variants.
- [ ] Define card styles.
- [ ] Define form control styles.
- [ ] Define visible focus states.

### Shared Layout

- [ ] Create or refine `_Layout.cshtml`.
- [ ] Build the site header.
- [ ] Build responsive navigation.
- [ ] Build the site footer.
- [ ] Build a reusable page hero.
- [ ] Build section heading patterns.
- [ ] Build reusable solution cards.
- [ ] Build reusable industry cards.
- [ ] Build reusable project cards.
- [ ] Build leadership cards.
- [ ] Build client and partner logo grids.
- [ ] Build contact information cards.

### Verification

- [ ] Test the mobile navigation.
- [ ] Check keyboard accessibility.
- [ ] Verify logo sizing.
- [ ] Check color contrast.
- [ ] Check responsive spacing.
- [ ] Compare the design with the approved source PDFs.

## Dependencies

Phase 0.

## Definition of Done

- [ ] Shared layout works on mobile, tablet, and desktop.
- [ ] Reusable components use consistent styling.
- [ ] Branding values are centralized.
- [ ] Navigation is keyboard accessible.
- [ ] No business datasets are duplicated in shared markup.

# Phase 2 — ViewModels, Mock Data, and Public Pages

## Part A: Data Foundations

- [ ] Create strongly typed ViewModels.
- [ ] Create content-provider interfaces.
- [ ] Create mock company-content data.
- [ ] Create mock leadership data.
- [ ] Create mock solution data.
- [ ] Create mock industry data.
- [ ] Create mock project data.
- [ ] Create mock client data.
- [ ] Create mock partner data.
- [ ] Create mock office-contact data.
- [ ] Register mock providers using dependency injection.
- [ ] Keep repeated datasets outside Razor views.
- [ ] Document source references for uncertain content.

## Part B: Home Page

- [ ] Build the hero section.
- [ ] Add the company introduction.
- [ ] Add approved credibility indicators.
- [ ] Add solution highlights (rendering exactly 6 core featured solutions selected via `IsFeatured = true`).
- [ ] Add industry highlights.
- [ ] Add selected project highlights.
- [ ] Add partner highlights.
- [ ] Add Contact calls to action.

## Part C: About Us

- [ ] Build the page hero.
- [ ] Add company overview.
- [ ] Add supported company history or milestones.
- [ ] Add mission and vision where confirmed.
- [ ] Add core values.
- [ ] Add verified geographic presence where appropriate.

## Part D: Leadership

- [ ] Build the leadership page.
- [ ] Add source-supported names and titles.
- [ ] Add approved portraits.
- [ ] Add biographies where available.
- [ ] Handle missing portraits gracefully.

## Part E: Services and Featured Solutions

- [ ] Render exactly 6 featured solutions on the Home page corresponding to the core brochure solutions.
- [ ] Render the full catalog of 8 service categories on the Services page (6 core brochure solutions + 2 specialized profile categories).
- [ ] Use `IsFeatured` on the centralized content model rather than duplicating or hardcoding selection logic in Razor markup.
- [ ] Preserve all source-grounded service categories, terminology, and descriptions from the 29-page profile and brochure.
- [ ] Verify that both the Home and Services pages consume data from the same centralized content source (`ITakyonContentProvider`).
- [ ] Build reusable, accessible solution card components with consistent typography, icons, and layout.

## Part F: Industries

- [ ] Build the Industries page.
- [ ] Add source-supported industry categories.
- [ ] Use consistent cards and descriptions.
- [ ] Add relevant project references only when supported.

## Part G: Projects

- [ ] Build the Projects page.
- [ ] Add brochure-supported project names.
- [ ] Add approved client information.
- [ ] Add project scope descriptions.
- [ ] Add approved project imagery.
- [ ] Avoid fabricated results or metrics.

## Part H: Clients and Partners

- [ ] Build the Clients page.
- [ ] Add approved client logos.
- [ ] Build the Partners page.
- [ ] Add approved OEM logos.
- [ ] Preserve logo proportions.
- [ ] Add accessible alternative text.
- [ ] Verify all local asset paths.

## Part I: Contact

- [ ] Build the Contact page.
- [ ] Add verified office contact information.
- [ ] Create the Contact form UI.
- [ ] Add form validation.
- [ ] Add a clear prototype-only submission state.
- [ ] Include QR functionality only after the payload is confirmed.

## Dependencies

Phase 1.

## Definition of Done

- [ ] All nine confirmed public pages render.
- [ ] Page data is supplied through typed ViewModels.
- [ ] Repeatable content is supplied through mock providers.
- [ ] Navigation works between confirmed pages.
- [ ] Source-supported content is used.
- [ ] No unsupported business claims are displayed as facts.
- [ ] The project builds successfully.

# Phase 3 — Interactions and UI Polish

## Tasks

- [ ] Implement client-side Contact form validation.
- [ ] Implement newsletter email validation.
- [ ] Add field-level error messages.
- [ ] Add accessible status messages.
- [ ] Clearly identify demo-only form behavior.
- [ ] Confirm the QR payload before implementing QR generation.
- [ ] Verify all buttons and links have defined actions.
- [ ] Remove dead links.
- [ ] Check mobile touch targets.
- [ ] Check image scaling.
- [ ] Add suitable image alternative text.
- [ ] Verify keyboard focus states.
- [ ] Review reduced-motion behavior if animation is used.
- [ ] Fix layout inconsistencies.
- [ ] Remove unnecessary dependencies and unused assets.

## Dependencies

Phase 2.

## Definition of Done

- [ ] Client-side form validation works.
- [ ] Demo forms do not claim to persist or send data.
- [ ] All visible interactive elements have meaningful behavior.
- [ ] No essential interaction requires a mouse.
- [ ] No critical responsive issues remain.

# Phase 4 — Testing and Frontend Approval

## Build and Functional Testing

- [ ] Run `dotnet build`.
- [ ] Run available automated tests.
- [ ] Open every confirmed public page.
- [ ] Test primary navigation links.
- [ ] Test footer links.
- [ ] Check all images and logos.
- [ ] Check browser console errors.
- [ ] Test empty form submissions.
- [ ] Test invalid email input.
- [ ] Test valid form input.
- [ ] Confirm the demo-only success message.
- [ ] Verify that no backend request is falsely implied.

## Responsive Testing

- [ ] Test at 320 px.
- [ ] Test at 375 px.
- [ ] Test at 768 px.
- [ ] Test at 1024 px.
- [ ] Test at 1440 px.
- [ ] Verify no unintended horizontal overflow.
- [ ] Check navigation and card grids at each width.

## Accessibility Testing

- [ ] Test keyboard-only navigation.
- [ ] Verify visible focus states.
- [ ] Check heading hierarchy.
- [ ] Check form labels.
- [ ] Check validation messages.
- [ ] Check image alt text.
- [ ] Check color contrast.

## Content Verification

- [ ] Compare company information against the updated profile.
- [ ] Compare project details against the A4 brochure.
- [ ] Verify leadership titles.
- [ ] Verify contact details.
- [ ] Verify client and OEM logos.
- [ ] Document unresolved discrepancies.

## Documentation

- [ ] Update README.md.
- [ ] Document how to run the project.
- [ ] Document mock data providers.
- [ ] Document known limitations.
- [ ] Record remaining open questions.
- [ ] Capture desktop and mobile screenshots.

## Dependencies

Phase 3.

## Definition of Done

- [ ] The build succeeds.
- [ ] Confirmed pages and primary interactions pass verification.
- [ ] No known critical UI or navigation defects remain.
- [ ] Content discrepancies are documented.
- [ ] The frontend is ready for stakeholder review.
- [ ] No backend, database, authentication, or CMS functionality has been implemented.

# Phase 5 — Backend and Database Integration (Future)

Do not begin this phase without explicit approval.

## Tasks

- [ ] Confirm business workflows.
- [ ] Define the database model.
- [ ] Design EF Core entities and relationships.
- [ ] Configure database connectivity.
- [ ] Add migrations.
- [ ] Introduce application services.
- [ ] Replace mock providers with real service implementations.
- [ ] Add server-side form validation.
- [ ] Add persistence for inquiries and subscriptions.
- [ ] Define email dispatch and failure handling.
- [ ] Add automated tests.
- [ ] Verify the frontend against real service data.

## Definition of Done

- [ ] Data persistence works in a non-production environment.
- [ ] Server-side validation is implemented.
- [ ] Errors are handled appropriately.
- [ ] Integration tests pass.
- [ ] No secrets are stored in source control.

# Phase 6 — Admin CMS and Security (Future)

Do not begin this phase until the CMS workflows and authorization requirements are approved.

## Tasks

### Authentication and Authorization

- [ ] Implement ASP.NET Core Identity.
- [ ] Define admin roles and permissions.
- [ ] Apply authorization policies.
- [ ] Secure state-changing operations.
- [ ] Configure appropriate session and cookie security.
- [ ] Add audit logging for sensitive operations.

### Inquiries and Leads

- [ ] Create inquiry management screens.
- [ ] Add inquiry listing and detail views.
- [ ] Define inquiry status management.
- [ ] Define retention and access policies.

### Blog and Knowledge Base

- [ ] Create article management screens.
- [ ] Add draft and publishing workflows.
- [ ] Add content validation.
- [ ] Define publication and revision behavior.

### Careers

- [ ] Create vacancy management screens.
- [ ] Add job application handling.
- [ ] Define file-upload restrictions if attachments are required.
- [ ] Define application privacy and retention policies.

### Projects and Portfolio

- [ ] Create project management screens.
- [ ] Add client and partner logo management.
- [ ] Define publication and approval behavior.
- [ ] Record important changes where required.

### Investor Disclosures

- [ ] Confirm regulatory and publication requirements.
- [ ] Create disclosure management screens.
- [ ] Implement secure file handling.
- [ ] Define approval and publication workflows.
- [ ] Add audit records.

## Definition of Done

- [ ] All CMS workflows have approved acceptance criteria.
- [ ] Authentication and authorization are tested.
- [ ] File handling and personal data protection are reviewed.
- [ ] Audit requirements are met.
- [ ] CMS integration tests pass.

# Phase 7 — Production Deployment (Future)

## Tasks

- [ ] Confirm hosting provider and deployment requirements.
- [ ] Configure production settings.
- [ ] Configure secrets securely.
- [ ] Configure HTTPS.
- [ ] Verify production database access.
- [ ] Configure logging and monitoring.
- [ ] Configure backups where required.
- [ ] Add deployment automation if approved.
- [ ] Perform final security and smoke tests.
- [ ] Verify production forms and email processing.
- [ ] Verify SEO metadata and sitemap.
- [ ] Document rollback and recovery procedures.

## Definition of Done

- [ ] Production configuration is verified.
- [ ] HTTPS works correctly.
- [ ] Monitoring and error handling are operational.
- [ ] Backup and recovery expectations are documented.
- [ ] Critical smoke tests pass.

# 8. Critical Dependencies

Follow this order:

1. Confirm requirements and inspect the repository.
2. Establish a working project baseline.
3. Build the design system and shared layout.
4. Create typed ViewModels and mock providers.
5. Build the confirmed public pages.
6. Implement client-side interactions.
7. Test responsiveness, accessibility, and content accuracy.
8. Obtain frontend approval.
9. Plan and implement backend integration.
10. Implement the CMS and security.
11. Prepare and verify production deployment.

# 9. Global Definition of Done

The initial frontend release is complete when:

- [ ] All confirmed public pages are implemented.
- [ ] Bootstrap 5 is used consistently.
- [ ] The design reflects the approved Takyon brand identity.
- [ ] Strongly typed ViewModels supply page content.
- [ ] Mock providers supply repeatable datasets.
- [ ] Navigation and links work correctly.
- [ ] Contact and newsletter forms use client-side validation.
- [ ] Demo-only behavior is communicated honestly.
- [ ] Mobile, tablet, and desktop layouts have been checked.
- [ ] Accessibility basics have been verified.
- [ ] The project builds successfully.
- [ ] Remaining open questions are documented.
- [ ] No backend, database, authentication, or CMS has been implemented.
- [ ] The project is ready for stakeholder review.

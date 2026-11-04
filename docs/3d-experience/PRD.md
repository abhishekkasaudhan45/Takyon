# Takyon 3D Experience — Product Requirements Document (PRD)

## 1. Executive Summary

This document specifies the product requirements for the **Cinematic Scroll-Driven 3D Homepage Experience** ("The Journey Through the Network") for Takyon Networks Limited.

The experience transforms the Takyon public homepage (`Pages/Index.cshtml`) into an interactive, high-fidelity visual narrative illustrating the company's full-spectrum systems integration and infrastructure capabilities. All internal pages (`/About`, `/Services`, `/Projects`, `/Contact`, etc.) remain lightweight, fast, conventional, and unchanged.

---

## 2. Product Goals & Objectives

1. **Visually Communicate Scale & Capability:** Seamlessly depict Takyon's capability across enterprise networking, cyber security, data center engineering, security surveillance, cloud managed services, and audiovisual collaboration.
2. **100% Procedural & Ultra-Performant:** Eliminate heavy 3D model downloads (`.glb`/`.gltf`); generate all geometry procedurally in WebGL to maintain instant load times and 60 FPS performance even on integrated GPUs.
3. **Enterprise & Government Tone (No E-Commerce):** Tailor the tone strictly to B2B enterprise leaders, PSU procurement officers (GeM portal), and government tenders.
4. **HTML-First Semantic Architecture:** Preserve all text, cards, statistics, and links as semantic Razor HTML over the WebGL canvas, ensuring 100% SEO indexability, screen reader accessibility, and keyboard navigation.
5. **Universal Accessibility & Reduced Motion:** Provide automatic detection for `prefers-reduced-motion` and a visible toggle (`3D View: ON / OFF`) allowing users to switch immediately to a clean, high-contrast static enterprise presentation.

---

## 3. Scope Boundaries

### In Scope
- Upgrade of `Pages/Index.cshtml` to host the WebGL canvas and scroll-driven overlays.
- Dedicated stylesheet `wwwroot/css/takyon-3d.css`.
- Modular client-side WebGL controller `wwwroot/js/takyon-3d-journey.js`.
- Localized dependencies: Three.js and GSAP/ScrollTrigger in `wwwroot/lib/`.
- Exposure of `IsFeatured` on `SolutionItemViewModel`.

### Out of Scope (Strictly Protected)
- Internal pages (`/About`, `/Leadership`, `/Services`, `/Industries`, `/Projects`, `/Clients`, `/Partners`, `/Contact`) must remain unaffected.
- No e-commerce features (shopping carts, checkout, retail catalog).
- No external model assets or remote CDN script dependencies for production runtime.
- No database or backend persistence modifications.

---

## 4. Scroll-Driven 9-Scene Storyboard

| Scene # | Scroll Range | 3D Visual State | HTML Overlay Content |
|---|---|---|---|
| **Scene 1: Hero** | 0% – 10% | Constellation of glowing Takyon blue (`#078BC5`) and brand green (`#83C341`) nodes; ambient data pulses; subtle mouse parallax. | Value proposition, BSE Listed & CMMI Level 3 credential pills, primary CTAs ("Explore Solutions", "Request Consultation"). |
| **Scene 2: Enterprise Networking** | 10% – 22% | Camera dives along glowing fiber splines into a 3D wireframe campus building; floor nodes illuminate in sequence. | Featured Solution 1: High-performance LAN/WAN, SD-WAN, and structured cabling capabilities. |
| **Scene 3: Cyber Security** | 22% – 34% | A geodesic wireframe security dome forms around the core node; incoming threat particles deflect and turn green upon inspection. | Featured Solution 2: Multi-layer cyber defense, Next-Gen Firewalls, DLP, IAM, and continuous monitoring. |
| **Scene 4: Data Center Solutions** | 34% – 46% | Camera navigates an instanced corridor of 3D server racks with active blinking LED arrays and vertical cooling streams. | Featured Solution 3: Turnkey data center engineering, power & precision cooling, virtualization, high availability. |
| **Scene 5: Security & Surveillance** | 46% – 58% | Isometric perimeter grid featuring sweeping volumetric surveillance cones and a glowing command-center scan ring. | Featured Solution 4: Integrated IP CCTV, perimeter intrusion detection, access control, centralized command center. |
| **Scene 6: Cloud & Managed Services** | 58% – 70% | Camera ascends into an elevated cluster of interconnected cloud nodes enveloped by a continuous 24/7 orbital support ring. | Featured Solution 5: Cloud migration, hybrid architecture, automated disaster recovery, 24/7 SLA managed services. |
| **Scene 7: AV & Collaboration** | 70% – 80% | Geometric smart boardroom and synchronized display matrices illuminating in unison as the camera approaches. | Featured Solution 6: Unified communications, smart classrooms, interactive displays, executive telepresence. |
| **Scene 8: Trust, Sectors & Projects** | 80% – 90% | Camera orbits a pan-India network hub connecting key infrastructure nodes across states. | Verified metrics (15+ Years, 1,000+ Projects, 40+ OEMs), 12 Industry Verticals, Notable Projects (AIIMS, UPSWAN, HAL), OEM logo strip. |
| **Scene 9: Final B2B Conversion Hub** | 90% – 100% | Camera pulls back to reveal the complete integrated network ecosystem in dynamic equilibrium. | B2B Conversion Hub: RFP/Tender inquiry CTA, Consultation booking, Company Profile download, corporate office directory. |

---

## 5. Non-Functional Requirements

1. **Performance:** Solid 60 FPS on standard desktop GPUs and 30–60 FPS on integrated mobile GPUs.
2. **Page Weight:** Procedural geometry keeps 3D asset transfer size to 0 KB beyond the JS libraries.
3. **Contrast & Readability:** All glassmorphic text overlays must maintain WCAG 2.2 AA contrast ratios (minimum 4.5:1 for body, 3:1 for large headings) over both 3D and fallback backgrounds.
4. **Resilience:** If WebGL context is lost, fails to initialize, or the user disables 3D, the site cleanly displays a rich, styled fallback background with zero broken layouts.

# Takyon 3D Experience — Implementation Plan

## 1. Overview & Strategy

This plan governs the delivery of the cinematic, scroll-scrubbed 3D homepage for Takyon Networks Limited. Work is executed iteratively with strict verification gates to ensure 0 broken builds, 0 regressions on internal routes, and 100% adherence to WCAG AA accessibility.

---

## 2. Phase Breakdown

### Phase 0 — Prerequisites & Library Setup
- [x] Create documentation structure in `docs/3d-experience/`.
- [x] Download and verify local libraries in `wwwroot/lib/three/` (`three.min.js`) and `wwwroot/lib/gsap/` (`gsap.min.js`, `ScrollTrigger.min.js`).
- [x] Ensure `SolutionItemViewModel` exposes `IsFeatured` mapped to `IsCoreBrochureSolution`.
- [x] Add `@await RenderSectionAsync("Styles", required: false)` to `Pages/Shared/_Layout.cshtml`.

### Phase 1 — Stylesheet & Glassmorphic Scrim System
- [ ] Create `wwwroot/css/takyon-3d.css`.
- [ ] Implement layout tokens for dark infrastructure void (`#061121` to `#12345B`).
- [ ] Implement fixed full-viewport canvas styling (`#takyon-3d-canvas`).
- [ ] Implement glassmorphic frosted card overlays (`rgba(6, 17, 33, 0.82)` with backdrop blur).
- [ ] Implement fixed right-side progress dot navigator and tooltip indicators.
- [ ] Implement floating 3D View Toggle button (`#takyon-3d-toggle`).
- [ ] Implement `prefers-reduced-motion` and static fallback CSS rules.

### Phase 2 — WebGL Scene Engine & Procedural Storyboard
- [ ] Create `wwwroot/js/takyon-3d-journey.js`.
- [ ] Implement WebGL feature detection and context loss recovery.
- [ ] Setup Three.js scene, perspective camera, ambient/directional lights, and FogExp2.
- [ ] Build Scene 1: Network Constellation with pulsing data connections.
- [ ] Build Scene 2: 3D Wireframe Campus Building with fiber optic risers.
- [ ] Build Scene 3: Geodesic Security Shield Dome with particle deflector.
- [ ] Build Scene 4: Instanced 3D Server Rack Corridor with blinking LEDs and cooling stream.
- [ ] Build Scene 5: Isometric Surveillance Grid with sweeping volumetric cones and radar sweep.
- [ ] Build Scene 6: Floating Cloud Nodes with 24/7 orbital SLA ring.
- [ ] Build Scene 7: Geometric Smart Boardroom with synchronized display matrices.
- [ ] Build Scene 8: Pan-India Network Hub and verified stat counters.
- [ ] Build Scene 9: Full Ecosystem macro pullback in equilibrium.
- [ ] Bind GSAP ScrollTrigger to page scroll to scrub camera positions and scene elements smoothly.
- [ ] Implement window resize handler and device pixel ratio capping (max 2).

### Phase 3 — Razor Page Integration & ViewModel Binding
- [ ] Update `Pages/Index.cshtml`:
  - Canvas element `<canvas id="takyon-3d-canvas" aria-hidden="true"></canvas>`.
  - Section progress navigator with 9 anchor targets.
  - 3D Toggle button UI with accessible `aria-pressed`.
  - 9 structured scroll sections directly bound to `IndexModel` data.
  - Script imports for Three.js, GSAP, ScrollTrigger, and `takyon-3d-journey.js` inside `@section Scripts`.
  - Stylesheet import inside `@section Styles`.

### Phase 4 — Testing & Quality Assurance
- [ ] Build verification (`dotnet build`) with 0 warnings, 0 errors.
- [ ] Automated route testing (`python test_routes.py`) verifying all 9 public routes return HTTP 200.
- [ ] Static asset verification: check that `takyon-3d.css`, `takyon-3d-journey.js`, and libraries load with HTTP 200.
- [ ] Verify 3D toggle functionality (switching between WebGL and static fallback mode).
- [ ] Verify keyboard accessibility and screen reader markup (`aria-hidden="true"` on canvas).
- [ ] Final implementation report.

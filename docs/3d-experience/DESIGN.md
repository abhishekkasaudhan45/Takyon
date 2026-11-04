# Takyon 3D Experience — UI/UX Design Specification

## 1. Visual Direction & Atmosphere

The Takyon 3D experience embodies a **cinematic, high-tech infrastructure universe**. It reflects high-reliability government and enterprise system integration rather than flashy consumer gaming.

### Color Palette

| Token | Hex Value | Role in 3D Scene / UI Overlay |
|---|---|---|
| **Deep Void Navy** | `#061121` | Primary background void & scene fog |
| **Corporate Navy** | `#12345B` | Structural elements, wireframes, card backgrounds |
| **Takyon Primary Blue** | `#078BC5` | Glowing data nodes, active network links, key UI buttons |
| **Takyon Electric Cyan** | `#00D2FF` | Core fiber pulses, LED indicators, active scan rings |
| **Takyon Brand Green** | `#83C341` | Validated packets, secure perimeter status, accent lines |
| **Dark Forest Green** | `#28764B` | Secondary green highlights and badges |
| **Alert Amber/Red** | `#FF5252` | Threat vectors deflecting off security shield |
| **Glass Overlay Scrim** | `rgba(6, 17, 33, 0.82)` | Frosted glassmorphism background for high readability |

---

## 2. Layout & Scrim Architecture

### Z-Index Hierarchy
- `z-index: 0`: Static fallback gradient background (`#061121` to `#12345B`).
- `z-index: 1`: Fixed WebGL canvas (`#takyon-3d-canvas`) covering 100vw x 100vh.
- `z-index: 10`: Semantic HTML scroll sections containing text, cards, and interactive buttons.
- `z-index: 50`: Fixed section progress navigator (vertical right-side dots) and 3D toggle button.

### Glassmorphism Overlays
All HTML overlay cards utilize frosted glassmorphic styling:
```css
background: rgba(6, 17, 33, 0.82);
backdrop-filter: blur(12px);
-webkit-backdrop-filter: blur(12px);
border: 1px solid rgba(7, 139, 197, 0.28);
box-shadow: 0 16px 36px rgba(0, 0, 0, 0.4);
```
This guarantees WCAG 2.2 AA contrast regardless of the camera's position or bright 3D geometry in the background.

---

## 3. Detailed 3D Scene Aesthetics

### 1. Hero Constellation
- Central cluster of 120+ glowing network nodes connected by dynamic line segments.
- Subtle rotational drift and mouse-position parallax.
- Data pulses travel between connected nodes at randomized intervals.

### 2. Enterprise Campus
- Wireframe multistory campus building formed by structured grid lines.
- Glowing vertical riser fiber cables connecting server basements to individual floors.
- Horizontal distribution lines illuminate as the camera dives inside.

### 3. Cyber Security Shield
- Geodesic dome structure enclosing the central network hub.
- Outer threat particles (amber/red) stream toward the dome, deflect upon contact, and transmute into verified green packets.
- Hexagonal pulse grid triggers on threat contact points.

### 4. Data Center Corridor
- Instanced 3D server rack corridors receding into infinite depth fog.
- Server rack faceplates with animated LED matrix textures/colors.
- Upward streaming cooling particle streams (blue/cyan) indicating airflow management.

### 5. Security & Surveillance Grid
- Ground grid with elevation contour lines.
- Rotating translucent volumetric light cones simulating PTZ cameras.
- Expanding radar/command-center scan wave emanating across the perimeter.

### 6. Cloud & Managed Services Hub
- Ascending floating cluster of interconnected cloud nodes.
- High-altitude particle clouds with an orbital 24/7 SLA governance ring rotating smoothly.
- Data synchronization pulses radiating downward to on-premises nodes.

### 7. AV & Collaboration Space
- Modern conference room wireframe table and seating silhouettes.
- Ultra-wide video wall matrix displays illuminating with synchronized presentation content.
- Soundwave/communication waveforms connecting display matrices.

### 8. Pan-India Hub & Trust Metrics
- Stylized 3D geographic network map showing interconnected hubs (Lucknow HQ, Delhi, Kolkata, Southern & Western hubs).
- Stat counters (15+ Years, 1,000+ Projects, 40+ OEMs) float over their respective regional nodes.

### 9. B2B Equilibrium Hub
- Complete system view pulling out into balanced macro-equilibrium.
- All 6 solution domains visible simultaneously, connected by glowing harmonic energy paths.

---

## 4. Section Progress Navigator & Accessibility Controls

### Fixed Right-Side Navigator
- 9 interactive circular dot indicators pinned to the right edge (`position: fixed; right: 24px; top: 50%; transform: translateY(-50%)`).
- Hovering or focusing displays a tooltip with the section name (e.g., "03. Cyber Security").
- Clicking smoothly scrolls the viewport to that exact scene.

### 3D View Toggle Button
- Prominently placed at the bottom-left or bottom-right corner.
- States:
  - `3D View: ON` (Default when WebGL supported and no reduced motion request).
  - `3D View: OFF` (Clean static dark enterprise backdrop, zero WebGL computation).
- Stored in `sessionStorage` or local state so user preference persists across homepage visits.

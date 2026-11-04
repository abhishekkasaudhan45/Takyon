/**
 * Takyon Networks — Cinematic Scroll-Driven 3D Journey
 * Procedural WebGL infrastructure world synchronized with GSAP ScrollTrigger
 * 100% Procedural Geometry — 0 KB external 3D model assets
 */

(function () {
  'use strict';

  // Check essential dependencies
  if (typeof window.THREE === 'undefined') {
    console.warn('[Takyon 3D] Three.js not found. 3D background disabled.');
    enableStaticFallbackMode();
    return;
  }

  const canvas = document.getElementById('takyon-3d-canvas');
  if (!canvas) {
    return;
  }

  // Pre-check WebGL support before creating renderer
  function hasWebGLSupport() {
    try {
      const testCanvas = document.createElement('canvas');
      return !!(window.WebGLRenderingContext && (testCanvas.getContext('webgl') || testCanvas.getContext('experimental-webgl')));
    } catch (e) {
      return false;
    }
  }

  function enableStaticFallbackMode() {
    document.body.classList.add('takyon-3d-disabled');
    is3DEnabled = false;
    isRunning = false;
    if (animationFrameId) {
      cancelAnimationFrame(animationFrameId);
      animationFrameId = null;
    }
  }

  if (!hasWebGLSupport()) {
    console.warn('[Takyon 3D] WebGL not supported on this device/browser. Activating static high-contrast fallback.');
    enableStaticFallbackMode();
    return;
  }

  // State management
  let is3DEnabled = true;
  let isRunning = false;
  let animationFrameId = null;
  let renderer, scene, camera;
  let clock;
  let currentScrollProgress = 0;

  // Scene object groups
  const groups = {
    heroConstellation: null,
    campusNetwork: null,
    cyberShield: null,
    dataCenter: null,
    surveillance: null,
    cloudCluster: null,
    avCollaboration: null,
    indiaHubs: null,
    equilibrium: null
  };

  // Animated elements storage
  const dynamicObjects = {
    heroParticles: null,
    threatParticles: null,
    datacenterCooling: null,
    datacenterLEDs: null,
    surveillanceCones: [],
    radarRing: null,
    orbitalRing: null,
    avDisplays: []
  };

  // Mouse interaction state
  const mouse = { x: 0, y: 0, targetX: 0, targetY: 0 };

  // Color constants aligned with Takyon Brand
  const COLORS = {
    bgVoid: 0x061121,
    blue: 0x078bc5,
    cyan: 0x00d2ff,
    green: 0x83c341,
    threatRed: 0xff4444,
    wireframe: 0x1a385c,
    wireframeDim: 0x0e243d,
    white: 0xffffff
  };

  // Camera waypoint spline coordinates (progress: 0.0 to 1.0)
  const CAMERA_WAYPOINTS = [
    { p: 0.00, pos: [0, 5, 45], look: [0, 0, 0] },       // Scene 1: Hero
    { p: 0.12, pos: [0, 5, 40], look: [0, 0, 0] },
    { p: 0.18, pos: [0, 2, 22], look: [0, -1, 0] },      // Scene 2: Enterprise Campus
    { p: 0.28, pos: [-10, 4, 18], look: [0, 1, 0] },     // Scene 3: Cyber Security
    { p: 0.40, pos: [0, 0, 12], look: [0, 0, -25] },     // Scene 4: Data Center Corridor
    { p: 0.52, pos: [14, 12, 16], look: [0, -2, 0] },    // Scene 5: Surveillance
    { p: 0.64, pos: [0, 18, 20], look: [0, 14, 0] },     // Scene 6: Cloud Services
    { p: 0.75, pos: [-7, 3, 15], look: [4, 2, 0] },      // Scene 7: AV & Collab
    { p: 0.86, pos: [0, 14, 36], look: [0, 0, 0] },      // Scene 8: Pan-India Trust
    { p: 1.00, pos: [0, 8, 48], look: [0, 1, 0] }        // Scene 9: Final B2B Hub
  ];

  // Helper: Vector interpolation between waypoints
  function getCameraTrajectory(progress) {
    const clamped = Math.max(0, Math.min(1, progress));
    let startPoint = CAMERA_WAYPOINTS[0];
    let endPoint = CAMERA_WAYPOINTS[CAMERA_WAYPOINTS.length - 1];

    for (let i = 0; i < CAMERA_WAYPOINTS.length - 1; i++) {
      if (clamped >= CAMERA_WAYPOINTS[i].p && clamped <= CAMERA_WAYPOINTS[i + 1].p) {
        startPoint = CAMERA_WAYPOINTS[i];
        endPoint = CAMERA_WAYPOINTS[i + 1];
        break;
      }
    }

    const range = endPoint.p - startPoint.p;
    const factor = range > 0 ? (clamped - startPoint.p) / range : 0;
    const smooth = factor * factor * (3 - 2 * factor);

    const pos = [
      startPoint.pos[0] + (endPoint.pos[0] - startPoint.pos[0]) * smooth,
      startPoint.pos[1] + (endPoint.pos[1] - startPoint.pos[1]) * smooth,
      startPoint.pos[2] + (endPoint.pos[2] - startPoint.pos[2]) * smooth
    ];

    const look = [
      startPoint.look[0] + (endPoint.look[0] - startPoint.look[0]) * smooth,
      startPoint.look[1] + (endPoint.look[1] - startPoint.look[1]) * smooth,
      startPoint.look[2] + (endPoint.look[2] - startPoint.look[2]) * smooth
    ];

    return { pos, look };
  }

  // Initialize WebGL Scene
  function initScene() {
    clock = new THREE.Clock();

    // 1. Renderer Setup with Error Handling
    try {
      renderer = new THREE.WebGLRenderer({
        canvas: canvas,
        antialias: true,
        alpha: true,
        powerPreference: 'high-performance'
      });
      renderer.setPixelRatio(Math.min(window.devicePixelRatio, 2));
      renderer.setSize(window.innerWidth, window.innerHeight);
      renderer.toneMapping = THREE.ACESFilmicToneMapping;
      renderer.toneMappingExposure = 1.1;
    } catch (e) {
      console.error('[Takyon 3D] WebGL renderer creation failed:', e);
      enableStaticFallbackMode();
      return;
    }

    // Attach WebGL context loss listeners
    canvas.addEventListener('webglcontextlost', function (event) {
      event.preventDefault();
      console.warn('[Takyon 3D] WebGL context lost. Pausing renderer and activating fallback.');
      isRunning = false;
      if (animationFrameId) {
        cancelAnimationFrame(animationFrameId);
        animationFrameId = null;
      }
      enableStaticFallbackMode();
    }, false);

    canvas.addEventListener('webglcontextrestored', function () {
      console.info('[Takyon 3D] WebGL context restored. Rebuilding scene.');
      if (is3DEnabled) {
        initScene();
      }
    }, false);

    // 2. Scene & Fog
    scene = new THREE.Scene();
    scene.fog = new THREE.FogExp2(COLORS.bgVoid, 0.016);

    // 3. Camera
    camera = new THREE.PerspectiveCamera(50, window.innerWidth / window.innerHeight, 0.1, 500);
    camera.position.set(0, 5, 45);

    // 4. Lighting
    const ambientLight = new THREE.AmbientLight(0x102540, 1.8);
    scene.add(ambientLight);

    const dirLight1 = new THREE.DirectionalLight(COLORS.cyan, 1.4);
    dirLight1.position.set(20, 40, 30);
    scene.add(dirLight1);

    const dirLight2 = new THREE.DirectionalLight(COLORS.green, 0.8);
    dirLight2.position.set(-20, -10, 20);
    scene.add(dirLight2);

    // 5. Build Procedural Scenes
    buildHeroConstellation();
    buildCampusNetwork();
    buildCyberSecurityShield();
    buildDataCenterCorridor();
    buildSurveillanceGrid();
    buildCloudCluster();
    buildAVCollaboration();
    buildIndiaTrustNetwork();
    buildEquilibriumHalo();

    // 6. Explicit initial visibility calibration
    updateSceneVisibility(0);

    // 7. Bind Event Handlers
    window.addEventListener('resize', onWindowResize, false);
    window.addEventListener('mousemove', onMouseMove, { passive: true });
    window.addEventListener('beforeunload', disposeSceneResources, false);

    // Tab visibility handling (pause rendering when tab is hidden)
    document.addEventListener('visibilitychange', onVisibilityChange, false);

    initToggleControl();
    initProgressNav();
    initScrollTrigger();

    // 8. Start Animation Loop ONLY if 3D is active
    if (is3DEnabled) {
      isRunning = true;
      animate();
    }
  }

  // --- SCENE 1: Hero Constellation ---
  function buildHeroConstellation() {
    const group = new THREE.Group();
    const nodeCount = 100;
    const geometry = new THREE.BufferGeometry();
    const positions = new Float32Array(nodeCount * 3);
    const colors = new Float32Array(nodeCount * 3);

    const colorBlue = new THREE.Color(COLORS.cyan);
    const colorGreen = new THREE.Color(COLORS.green);

    for (let i = 0; i < nodeCount; i++) {
      const radius = 18 + Math.random() * 12;
      const theta = Math.random() * Math.PI * 2;
      const phi = Math.acos(2 * Math.random() - 1);

      const x = radius * Math.sin(phi) * Math.cos(theta);
      const y = radius * Math.sin(phi) * Math.sin(theta);
      const z = radius * Math.cos(phi);

      positions[i * 3] = x;
      positions[i * 3 + 1] = y;
      positions[i * 3 + 2] = z;

      const c = Math.random() > 0.4 ? colorBlue : colorGreen;
      colors[i * 3] = c.r;
      colors[i * 3 + 1] = c.g;
      colors[i * 3 + 2] = c.b;
    }

    geometry.setAttribute('position', new THREE.BufferAttribute(positions, 3));
    geometry.setAttribute('color', new THREE.BufferAttribute(colors, 3));

    const material = new THREE.PointsMaterial({
      size: 0.9,
      vertexColors: true,
      transparent: true,
      opacity: 0.85
    });

    const points = new THREE.Points(geometry, material);
    group.add(points);

    // Connecting Lines
    const lineIndices = [];
    for (let i = 0; i < nodeCount; i++) {
      for (let j = i + 1; j < nodeCount; j++) {
        const dx = positions[i * 3] - positions[j * 3];
        const dy = positions[i * 3 + 1] - positions[j * 3 + 1];
        const dz = positions[i * 3 + 2] - positions[j * 3 + 2];
        const dist = Math.sqrt(dx * dx + dy * dy + dz * dz);
        if (dist < 9.5) {
          lineIndices.push(i, j);
        }
      }
    }

    const lineGeo = new THREE.BufferGeometry();
    lineGeo.setAttribute('position', new THREE.BufferAttribute(positions, 3));
    lineGeo.setIndex(lineIndices);

    const lineMat = new THREE.LineBasicMaterial({
      color: COLORS.blue,
      transparent: true,
      opacity: 0.35
    });

    const lines = new THREE.LineSegments(lineGeo, lineMat);
    group.add(lines);

    groups.heroConstellation = group;
    scene.add(group);
  }

  // --- SCENE 2: Enterprise Campus ---
  function buildCampusNetwork() {
    const group = new THREE.Group();
    group.position.set(0, -2, 0);

    // Campus Wireframe Building
    const boxGeo = new THREE.BoxGeometry(16, 12, 10, 4, 3, 3);
    const wireMat = new THREE.LineBasicMaterial({
      color: COLORS.cyan,
      transparent: true,
      opacity: 0.3
    });
    const wireframe = new THREE.LineSegments(new THREE.WireframeGeometry(boxGeo), wireMat);
    group.add(wireframe);

    // Vertical Fiber Riser Line
    const riserGeo = new THREE.BufferGeometry().setFromPoints([
      new THREE.Vector3(0, -6, 0),
      new THREE.Vector3(0, 6, 0)
    ]);
    const riserMat = new THREE.LineBasicMaterial({
      color: COLORS.green,
      linewidth: 3
    });
    const riser = new THREE.Line(riserGeo, riserMat);
    group.add(riser);

    // Floor distribution nodes
    for (let y = -4; y <= 4; y += 4) {
      const ringGeo = new THREE.RingGeometry(2.5, 2.7, 16);
      const ringMat = new THREE.MeshBasicMaterial({
        color: COLORS.cyan,
        side: THREE.DoubleSide,
        transparent: true,
        opacity: 0.4
      });
      const ring = new THREE.Mesh(ringGeo, ringMat);
      ring.rotation.x = Math.PI / 2;
      ring.position.y = y;
      group.add(ring);
    }

    groups.campusNetwork = group;
    group.visible = false;
    scene.add(group);
  }

  // --- SCENE 3: Cyber Security Geodesic Shield ---
  function buildCyberSecurityShield() {
    const group = new THREE.Group();
    group.position.set(0, 1, 0);

    // Geodesic Dome Wireframe
    const domeGeo = new THREE.IcosahedronGeometry(10, 2);
    const domeMat = new THREE.LineBasicMaterial({
      color: COLORS.cyan,
      transparent: true,
      opacity: 0.45
    });
    const dome = new THREE.LineSegments(new THREE.WireframeGeometry(domeGeo), domeMat);
    group.add(dome);

    // Core Secure Node
    const coreGeo = new THREE.SphereGeometry(2, 24, 24);
    const coreMat = new THREE.MeshBasicMaterial({
      color: COLORS.green,
      wireframe: true,
      transparent: true,
      opacity: 0.7
    });
    const core = new THREE.Mesh(coreGeo, coreMat);
    group.add(core);

    // Threat Particles
    const threatCount = 80;
    const threatGeo = new THREE.BufferGeometry();
    const threatPos = new Float32Array(threatCount * 3);
    const threatCols = new Float32Array(threatCount * 3);

    for (let i = 0; i < threatCount; i++) {
      const theta = Math.random() * Math.PI * 2;
      const r = 12 + Math.random() * 8;
      threatPos[i * 3] = Math.cos(theta) * r;
      threatPos[i * 3 + 1] = (Math.random() - 0.5) * 10;
      threatPos[i * 3 + 2] = Math.sin(theta) * r;

      threatCols[i * 3] = 1.0;
      threatCols[i * 3 + 1] = 0.2;
      threatCols[i * 3 + 2] = 0.2;
    }

    threatGeo.setAttribute('position', new THREE.BufferAttribute(threatPos, 3));
    threatGeo.setAttribute('color', new THREE.BufferAttribute(threatCols, 3));

    const threatMat = new THREE.PointsMaterial({
      size: 0.7,
      vertexColors: true,
      transparent: true,
      opacity: 0.9
    });

    const threatPoints = new THREE.Points(threatGeo, threatMat);
    group.add(threatPoints);
    dynamicObjects.threatParticles = threatPoints;

    groups.cyberShield = group;
    group.visible = false;
    scene.add(group);
  }

  // --- SCENE 4: Data Center Corridor ---
  function buildDataCenterCorridor() {
    const group = new THREE.Group();
    group.position.set(0, 0, 0);

    // Instanced Mesh for Server Racks (40 racks: 2 rows of 20)
    const rackCount = 40;
    const rackGeo = new THREE.BoxGeometry(1.6, 5.5, 2.2);
    const rackMat = new THREE.MeshLambertMaterial({
      color: 0x0a1c33,
      emissive: 0x051326
    });

    const instancedRacks = new THREE.InstancedMesh(rackGeo, rackMat, rackCount);
    const matrix = new THREE.Matrix4();
    let idx = 0;

    for (let row = -1; row <= 1; row += 2) {
      for (let z = 0; z < 20; z++) {
        const x = row * 3.8;
        const y = 0;
        const zPos = -z * 3.5;
        matrix.setPosition(x, y, zPos);
        instancedRacks.setMatrixAt(idx++, matrix);
      }
    }
    instancedRacks.instanceMatrix.needsUpdate = true;
    group.add(instancedRacks);

    // Rack LED matrix points
    const ledCount = 200;
    const ledGeo = new THREE.BufferGeometry();
    const ledPos = new Float32Array(ledCount * 3);
    const ledCols = new Float32Array(ledCount * 3);

    for (let i = 0; i < ledCount; i++) {
      const isLeft = Math.random() > 0.5;
      ledPos[i * 3] = isLeft ? -2.95 : 2.95;
      ledPos[i * 3 + 1] = (Math.random() - 0.5) * 5;
      ledPos[i * 3 + 2] = -Math.random() * 65;

      const isGreen = Math.random() > 0.3;
      ledCols[i * 3] = isGreen ? 0.5 : 0.0;
      ledCols[i * 3 + 1] = isGreen ? 1.0 : 0.8;
      ledCols[i * 3 + 2] = isGreen ? 0.2 : 1.0;
    }

    ledGeo.setAttribute('position', new THREE.BufferAttribute(ledPos, 3));
    ledGeo.setAttribute('color', new THREE.BufferAttribute(ledCols, 3));

    const ledMat = new THREE.PointsMaterial({
      size: 0.45,
      vertexColors: true,
      transparent: true,
      opacity: 0.95
    });
    const leds = new THREE.Points(ledGeo, ledMat);
    group.add(leds);
    dynamicObjects.datacenterLEDs = leds;

    // Upward cooling airflow particles
    const coolingCount = 120;
    const coolGeo = new THREE.BufferGeometry();
    const coolPos = new Float32Array(coolingCount * 3);

    for (let i = 0; i < coolingCount; i++) {
      coolPos[i * 3] = (Math.random() - 0.5) * 3.0;
      coolPos[i * 3 + 1] = (Math.random() - 0.5) * 6;
      coolPos[i * 3 + 2] = -Math.random() * 65;
    }

    coolGeo.setAttribute('position', new THREE.BufferAttribute(coolPos, 3));
    const coolMat = new THREE.PointsMaterial({
      color: COLORS.cyan,
      size: 0.35,
      transparent: true,
      opacity: 0.75
    });

    const cooling = new THREE.Points(coolGeo, coolMat);
    group.add(cooling);
    dynamicObjects.datacenterCooling = cooling;

    groups.dataCenter = group;
    group.visible = false;
    scene.add(group);
  }

  // --- SCENE 5: Security & Surveillance Grid ---
  function buildSurveillanceGrid() {
    const group = new THREE.Group();
    group.position.set(0, -2, 0);

    // Ground Grid
    const grid = new THREE.GridHelper(50, 25, COLORS.cyan, COLORS.wireframeDim);
    group.add(grid);

    // Sweeping surveillance volumetric light cones
    const coneCount = 4;
    const conePositions = [
      [-12, 6, -10],
      [12, 6, -10],
      [-10, 6, 8],
      [10, 6, 8]
    ];

    for (let i = 0; i < coneCount; i++) {
      const conePivot = new THREE.Group();
      conePivot.position.set(...conePositions[i]);

      const coneGeo = new THREE.ConeGeometry(4, 9, 16, 1, true);
      const coneMat = new THREE.MeshBasicMaterial({
        color: COLORS.cyan,
        transparent: true,
        opacity: 0.22,
        side: THREE.DoubleSide
      });

      const coneMesh = new THREE.Mesh(coneGeo, coneMat);
      coneMesh.rotation.x = Math.PI / 1.35;
      conePivot.add(coneMesh);

      group.add(conePivot);
      dynamicObjects.surveillanceCones.push(conePivot);
    }

    // Radar scan ring on ground
    const ringGeo = new THREE.RingGeometry(1, 1.8, 32);
    const ringMat = new THREE.MeshBasicMaterial({
      color: COLORS.green,
      side: THREE.DoubleSide,
      transparent: true,
      opacity: 0.6
    });
    const radar = new THREE.Mesh(ringGeo, ringMat);
    radar.rotation.x = -Math.PI / 2;
    radar.position.y = 0.05;
    group.add(radar);
    dynamicObjects.radarRing = radar;

    groups.surveillance = group;
    group.visible = false;
    scene.add(group);
  }

  // --- SCENE 6: Cloud & Managed Services Cluster ---
  function buildCloudCluster() {
    const group = new THREE.Group();
    group.position.set(0, 14, 0);

    const clusterPositions = [
      [0, 0, 0, 3.5],
      [-3.5, 0.5, 1, 2.5],
      [3.2, -0.4, 0.8, 2.6],
      [-1.8, 1.8, -1.2, 2.2],
      [1.5, 1.6, -1, 2.4]
    ];

    clusterPositions.forEach(cp => {
      const sphereGeo = new THREE.SphereGeometry(cp[3], 20, 20);
      const sphereMat = new THREE.MeshLambertMaterial({
        color: COLORS.blue,
        emissive: 0x051b33,
        wireframe: true,
        transparent: true,
        opacity: 0.4
      });
      const s = new THREE.Mesh(sphereGeo, sphereMat);
      s.position.set(cp[0], cp[1], cp[2]);
      group.add(s);
    });

    // 24/7 Orbital Ring
    const orbitGeo = new THREE.TorusGeometry(8.5, 0.15, 16, 80);
    const orbitMat = new THREE.MeshBasicMaterial({
      color: COLORS.green,
      transparent: true,
      opacity: 0.7
    });
    const orbit = new THREE.Mesh(orbitGeo, orbitMat);
    orbit.rotation.x = Math.PI / 2.6;
    group.add(orbit);
    dynamicObjects.orbitalRing = orbit;

    groups.cloudCluster = group;
    group.visible = false;
    scene.add(group);
  }

  // --- SCENE 7: AV & Collaboration Smart Space ---
  function buildAVCollaboration() {
    const group = new THREE.Group();
    group.position.set(4, 2, 0);

    // Large video wall display frames
    const displayCount = 3;
    for (let i = 0; i < displayCount; i++) {
      const frameGeo = new THREE.PlaneGeometry(4.5, 2.8);
      const frameMat = new THREE.MeshBasicMaterial({
        color: i === 1 ? COLORS.green : COLORS.cyan,
        wireframe: true,
        transparent: true,
        opacity: 0.55
      });
      const screen = new THREE.Mesh(frameGeo, frameMat);
      screen.position.set((i - 1) * 5.2, 0, 0);
      group.add(screen);
      dynamicObjects.avDisplays.push(screen);
    }

    // Boardroom conference table wireframe
    const tableGeo = new THREE.CylinderGeometry(5.5, 5.5, 0.3, 16);
    const tableMat = new THREE.LineBasicMaterial({
      color: COLORS.blue,
      transparent: true,
      opacity: 0.35
    });
    const table = new THREE.LineSegments(new THREE.WireframeGeometry(tableGeo), tableMat);
    table.position.set(0, -3.2, 5);
    table.scale.set(1.4, 1, 0.7);
    group.add(table);

    groups.avCollaboration = group;
    group.visible = false;
    scene.add(group);
  }

  // --- SCENE 8: Pan-India Trust Network ---
  function buildIndiaTrustNetwork() {
    const group = new THREE.Group();
    group.position.set(0, 0, 0);

    const hubs = [
      { name: 'Lucknow HQ', pos: [0, 2.5, 0], isHQ: true },
      { name: 'Delhi NCR', pos: [-4, 5, 1], isHQ: false },
      { name: 'Kolkata East', pos: [7, 1.5, 0], isHQ: false },
      { name: 'Western Hub', pos: [-6, -2, -1], isHQ: false },
      { name: 'Southern Hub', pos: [1, -7, 0], isHQ: false }
    ];

    const hubPoints = [];
    hubs.forEach(h => {
      const size = h.isHQ ? 1.2 : 0.7;
      const sphereGeo = new THREE.SphereGeometry(size, 16, 16);
      const sphereMat = new THREE.MeshBasicMaterial({
        color: h.isHQ ? COLORS.green : COLORS.cyan,
        wireframe: true
      });
      const mesh = new THREE.Mesh(sphereGeo, sphereMat);
      mesh.position.set(...h.pos);
      group.add(mesh);
      hubPoints.push(new THREE.Vector3(...h.pos));
    });

    const hqPos = hubPoints[0];
    for (let i = 1; i < hubPoints.length; i++) {
      const lineGeo = new THREE.BufferGeometry().setFromPoints([hqPos, hubPoints[i]]);
      const lineMat = new THREE.LineBasicMaterial({
        color: COLORS.cyan,
        transparent: true,
        opacity: 0.6
      });
      group.add(new THREE.Line(lineGeo, lineMat));
    }

    groups.indiaHubs = group;
    group.visible = false;
    scene.add(group);
  }

  // --- SCENE 9: Equilibrium Halo ---
  function buildEquilibriumHalo() {
    const group = new THREE.Group();
    group.position.set(0, 1, 0);

    const ringCount = 3;
    for (let i = 0; i < ringCount; i++) {
      const ringGeo = new THREE.TorusGeometry(14 + i * 4, 0.1, 16, 100);
      const ringMat = new THREE.MeshBasicMaterial({
        color: i % 2 === 0 ? COLORS.cyan : COLORS.green,
        transparent: true,
        opacity: 0.35 - i * 0.08
      });
      const ring = new THREE.Mesh(ringGeo, ringMat);
      ring.rotation.x = Math.PI / (2 + i * 0.4);
      ring.rotation.y = i * 0.5;
      group.add(ring);
    }

    groups.equilibrium = group;
    group.visible = false;
    scene.add(group);
  }

  // Handle Mouse Parallax
  function onMouseMove(event) {
    mouse.targetX = (event.clientX / window.innerWidth) * 2 - 1;
    mouse.targetY = -(event.clientY / window.innerHeight) * 2 + 1;
  }

  // Handle Window Resize with ScrollTrigger Refresh
  function onWindowResize() {
    if (!renderer || !camera) return;
    camera.aspect = window.innerWidth / window.innerHeight;
    camera.updateProjectionMatrix();
    renderer.setSize(window.innerWidth, window.innerHeight);
    renderer.setPixelRatio(Math.min(window.devicePixelRatio, 2));

    if (window.ScrollTrigger) {
      window.ScrollTrigger.refresh();
    }
  }

  // Handle Tab Visibility (Pause rendering when tab is hidden to save GPU/CPU)
  function onVisibilityChange() {
    if (document.hidden) {
      isRunning = false;
      if (animationFrameId) {
        cancelAnimationFrame(animationFrameId);
        animationFrameId = null;
      }
    } else {
      if (is3DEnabled && !isRunning) {
        isRunning = true;
        if (clock) clock.getDelta();
        animate();
      }
    }
  }

  // Dispose Scene Resources on page unload
  function disposeSceneResources() {
    if (!scene) return;
    scene.traverse(function (object) {
      if (object.geometry) {
        object.geometry.dispose();
      }
      if (object.material) {
        if (Array.isArray(object.material)) {
          object.material.forEach(m => m.dispose());
        } else {
          object.material.dispose();
        }
      }
    });
  }

  // GSAP ScrollTrigger Integration
  function initScrollTrigger() {
    if (typeof window.gsap === 'undefined' || typeof window.ScrollTrigger === 'undefined') {
      console.warn('[Takyon 3D] GSAP ScrollTrigger not available. Using scroll listener.');
      window.addEventListener('scroll', onNativeScroll, { passive: true });
      return;
    }

    window.gsap.registerPlugin(window.ScrollTrigger);

    window.ScrollTrigger.create({
      trigger: document.body,
      start: 'top top',
      end: 'bottom bottom',
      scrub: 1.2,
      onUpdate: (self) => {
        currentScrollProgress = self.progress;
        updateSceneVisibility(self.progress);
        updateProgressNav(self.progress);
      }
    });
  }

  // Fallback native scroll listener if GSAP is blocked
  function onNativeScroll() {
    const maxScroll = document.documentElement.scrollHeight - window.innerHeight;
    if (maxScroll <= 0) return;
    const progress = Math.max(0, Math.min(1, window.scrollY / maxScroll));
    currentScrollProgress = progress;
    updateSceneVisibility(progress);
    updateProgressNav(progress);
  }

  // Selective scene visibility for performance
  function updateSceneVisibility(p) {
    if (groups.heroConstellation) groups.heroConstellation.visible = p < 0.18;
    if (groups.campusNetwork) groups.campusNetwork.visible = p >= 0.10 && p < 0.28;
    if (groups.cyberShield) groups.cyberShield.visible = p >= 0.20 && p < 0.38;
    if (groups.dataCenter) groups.dataCenter.visible = p >= 0.32 && p < 0.50;
    if (groups.surveillance) groups.surveillance.visible = p >= 0.44 && p < 0.62;
    if (groups.cloudCluster) groups.cloudCluster.visible = p >= 0.56 && p < 0.74;
    if (groups.avCollaboration) groups.avCollaboration.visible = p >= 0.68 && p < 0.84;
    if (groups.indiaHubs) groups.indiaHubs.visible = p >= 0.78 && p < 0.94;
    if (groups.equilibrium) groups.equilibrium.visible = p >= 0.88;
  }

  // Update Section Progress Navigator active state
  function updateProgressNav(progress) {
    const navItems = document.querySelectorAll('.t3d-nav-item');
    if (!navItems.length) return;

    const sceneCount = navItems.length;
    const activeIndex = Math.min(sceneCount - 1, Math.floor(progress * sceneCount));

    navItems.forEach((item, idx) => {
      if (idx === activeIndex) {
        item.classList.add('active');
      } else {
        item.classList.remove('active');
      }
    });
  }

  // Accessibility & Motion Preference Handling (No floating button)
  function initToggleControl() {
    const prefersReduced = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    if (prefersReduced) {
      set3DState(false);
    } else {
      set3DState(true);
    }
  }

  function set3DState(enable) {
    is3DEnabled = enable;
    if (is3DEnabled) {
      document.body.classList.remove('takyon-3d-disabled');
      if (!isRunning) {
        isRunning = true;
        if (clock) clock.getDelta();
        animate();
      }
    } else {
      document.body.classList.add('takyon-3d-disabled');
      isRunning = false;
      if (animationFrameId) {
        cancelAnimationFrame(animationFrameId);
        animationFrameId = null;
      }
    }
  }

  // Navigation click-to-scroll handler
  function initProgressNav() {
    const navLinks = document.querySelectorAll('.t3d-nav-dot');
    navLinks.forEach(link => {
      link.addEventListener('click', function (e) {
        e.preventDefault();
        const targetId = this.getAttribute('href');
        const targetEl = document.querySelector(targetId);
        if (targetEl) {
          targetEl.scrollIntoView({ behavior: 'smooth' });
        }
      });
    });
  }

  // Main Render Animation Loop
  function animate() {
    if (!isRunning || !is3DEnabled || !renderer || !scene || !camera) return;

    animationFrameId = requestAnimationFrame(animate);

    const delta = clock.getDelta();
    const elapsedTime = clock.getElapsedTime();

    // Mouse parallax easing
    mouse.x += (mouse.targetX - mouse.x) * 0.05;
    mouse.y += (mouse.targetY - mouse.y) * 0.05;

    // Interpolate camera to scroll trajectory
    const trajectory = getCameraTrajectory(currentScrollProgress);
    camera.position.x = trajectory.pos[0] + mouse.x * 1.5;
    camera.position.y = trajectory.pos[1] + mouse.y * 1.2;
    camera.position.z = trajectory.pos[2];

    const lookTarget = new THREE.Vector3(
      trajectory.look[0] + mouse.x * 0.5,
      trajectory.look[1] + mouse.y * 0.5,
      trajectory.look[2]
    );
    camera.lookAt(lookTarget);

    // Dynamic procedural animations
    // 1. Hero Constellation drift
    if (groups.heroConstellation && groups.heroConstellation.visible) {
      groups.heroConstellation.rotation.y = elapsedTime * 0.08;
      groups.heroConstellation.rotation.x = Math.sin(elapsedTime * 0.05) * 0.05;
    }

    // 2. Cyber Shield rotation & threat particle animation
    if (groups.cyberShield && groups.cyberShield.visible) {
      groups.cyberShield.rotation.y = elapsedTime * 0.15;
      if (dynamicObjects.threatParticles) {
        const pos = dynamicObjects.threatParticles.geometry.attributes.position.array;
        for (let i = 0; i < pos.length; i += 3) {
          pos[i] *= 0.995;
          pos[i + 2] *= 0.995;
          const dist = Math.sqrt(pos[i] * pos[i] + pos[i + 2] * pos[i + 2]);
          if (dist < 10) {
            pos[i] = (Math.random() - 0.5) * 35;
            pos[i + 2] = (Math.random() - 0.5) * 35;
          }
        }
        dynamicObjects.threatParticles.geometry.attributes.position.needsUpdate = true;
      }
    }

    // 3. Data Center airflow & LED blinking
    if (groups.dataCenter && groups.dataCenter.visible) {
      if (dynamicObjects.datacenterCooling) {
        const pos = dynamicObjects.datacenterCooling.geometry.attributes.position.array;
        for (let i = 1; i < pos.length; i += 3) {
          pos[i] += delta * 4.5;
          if (pos[i] > 3) pos[i] = -3;
        }
        dynamicObjects.datacenterCooling.geometry.attributes.position.needsUpdate = true;
      }
    }

    // 4. Surveillance Cones sweep
    if (groups.surveillance && groups.surveillance.visible) {
      dynamicObjects.surveillanceCones.forEach((cone, idx) => {
        cone.rotation.y = Math.sin(elapsedTime * 0.8 + idx) * 0.6;
      });
      if (dynamicObjects.radarRing) {
        const s = 1 + (elapsedTime * 1.5) % 8;
        dynamicObjects.radarRing.scale.set(s, s, s);
        dynamicObjects.radarRing.material.opacity = Math.max(0, 0.7 - s * 0.08);
      }
    }

    // 5. Cloud 24/7 Orbital Ring rotation
    if (groups.cloudCluster && groups.cloudCluster.visible && dynamicObjects.orbitalRing) {
      dynamicObjects.orbitalRing.rotation.z = elapsedTime * 0.4;
    }

    // 6. AV Displays pulse
    if (groups.avCollaboration && groups.avCollaboration.visible) {
      dynamicObjects.avDisplays.forEach((disp, idx) => {
        disp.material.opacity = 0.45 + Math.sin(elapsedTime * 2 + idx) * 0.2;
      });
    }

    // 7. Equilibrium rings rotation
    if (groups.equilibrium && groups.equilibrium.visible) {
      groups.equilibrium.rotation.y = elapsedTime * 0.12;
      groups.equilibrium.rotation.z = Math.sin(elapsedTime * 0.1) * 0.1;
    }

    renderer.render(scene, camera);
  }

  // Run on DOM Ready
  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initScene);
  } else {
    initScene();
  }
})();
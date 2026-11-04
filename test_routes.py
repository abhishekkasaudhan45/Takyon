import subprocess
import time
import urllib.request
import sys

port = 5123
base_url = f"http://127.0.0.1:{port}"

print(f"Starting Takyon application on {base_url}...")
proc = subprocess.Popen(
    ["dotnet", "bin/Debug/net10.0/Takyon.dll", "--urls", base_url],
    stdout=subprocess.PIPE,
    stderr=subprocess.PIPE,
    text=True
)

# Wait for server to start
max_retries = 20
started = False
for i in range(max_retries):
    time.sleep(0.5)
    try:
        with urllib.request.urlopen(f"{base_url}/", timeout=2) as resp:
            if resp.status == 200:
                started = True
                print("Server is up and responding!")
                break
    except Exception:
        pass

if not started:
    print("Server failed to respond within timeout.")
    proc.terminate()
    sys.exit(1)

routes_to_test = [
    # Confirmed Public Pages
    ("/", "Digital Transformation Partner"),
    ("/About", "About Takyon Networks Limited"),
    ("/Leadership", "Our Leadership Team"),
    ("/Services", "IT Solutions"),
    ("/Industries", "Industry Verticals We Serve"),
    ("/Projects", "Notable Projects"),
    ("/Clients", "Client Portfolio"),
    ("/Partners", "Strategic OEM Partnerships"),
    ("/Contact", "Contact Us"),
    # Critical Static Assets
    ("/css/site.css", "--takyon-blue"),
    ("/css/takyon-3d.css", "takyon-3d-page"),
    ("/js/forms.js", "takyonContactForm"),
    ("/js/site.js", "Takyon Networks Limited"),
    ("/js/takyon-3d-journey.js", "takyon-3d-canvas"),
    ("/lib/three/three.min.js", None),
    ("/lib/gsap/gsap.min.js", None),
    ("/lib/gsap/ScrollTrigger.min.js", None),
    ("/images/brand/takyon-logo.png", None),
    ("/images/leadership/manish-sharma.jpg", None),
    ("/images/leadership/neeraj-kumar.jpg", None),
    ("/images/projects/aiims-bibinagar.jpg", None),
    ("/images/projects/rdso-telecom.jpg", None),
    ("/images/clients/indian-army.jpg", None),
    ("/images/clients/nabard.jpg", None),
    ("/images/partners/dell.png", None),
    ("/images/partners/microsoft.png", None),
    ("/images/badges/bse-listed.png", None),
]

all_passed = True
results = []

for route, expected_text in routes_to_test:
    url = f"{base_url}{route}"
    try:
        req = urllib.request.Request(url, headers={"User-Agent": "RouteVerificationTester/1.0"})
        with urllib.request.urlopen(req, timeout=5) as resp:
            status = resp.status
            content = resp.read()
            text_matched = True
            if expected_text:
                text_matched = expected_text.encode("utf-8") in content
            
            if status == 200 and text_matched:
                results.append((route, status, len(content), "PASS"))
                print(f"[PASS] {route} -> HTTP {status} ({len(content)} bytes)")
            else:
                all_passed = False
                results.append((route, status, len(content), "TEXT_MISMATCH" if not text_matched else f"HTTP_{status}"))
                print(f"[FAIL] {route} -> HTTP {status}, text match: {text_matched}")
    except Exception as e:
        all_passed = False
        results.append((route, "ERR", 0, str(e)))
        print(f"[FAIL] {route} -> Error: {e}")

print("\nTerminating server...")
proc.terminate()
try:
    proc.wait(timeout=5)
except Exception:
    proc.kill()

print("\n=== ROUTE & CONTENT VERIFICATION SUMMARY ===")
print(f"Total Routes Tested: {len(results)}")
pass_count = sum(1 for r in results if r[3] == "PASS")
print(f"Passed: {pass_count}/{len(results)}")

if not all_passed:
    sys.exit(1)
print("All 9 confirmed public pages and essential static assets verified with 100% PASS rate!")

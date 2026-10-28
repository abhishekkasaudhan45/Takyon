using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Content.Mock;

public class MockTakyonContentProvider : ITakyonContentProvider
{
    private readonly CompanyOverviewViewModel _overview;
    private readonly List<LeadershipMemberViewModel> _leadership;
    private readonly List<SolutionItemViewModel> _solutions;
    private readonly List<IndustryVerticalViewModel> _industries;
    private readonly List<ProjectCaseStudyViewModel> _projects;
    private readonly List<ClientLogoViewModel> _clients;
    private readonly List<PartnerLogoViewModel> _partners;
    private readonly List<OfficeContactViewModel> _offices;
    private readonly List<string> _discrepancies;

    public MockTakyonContentProvider()
    {
        _overview = new CompanyOverviewViewModel
        {
            CompanyName = "Takyon Networks Limited",
            Tagline = "Passion for Integration",
            FoundedYear = 2009,
            Headquarters = "Lucknow, Uttar Pradesh",
            BseStatus = "BSE Listed Company (Listed August 2025)",
            CmmiStatus = "CMMI Level 3 Appraised",
            GemStatus = "GeM Registered (Direct Government Procurement)",
            Mission = "To collaborate with esteemed organizations in their digital transformation journey that will create noticeable, long-term, and significant improvements in their operations.",
            Vision = "To be recognized across the globe as the specialist in our sector of expertise by offering unmatched quality of our products and services.",
            OverviewParagraphs = new List<string>
            {
                "Takyon Networks Limited is a trusted system integrator and IT infrastructure solutions provider, helping organizations build a secure, agile and future-ready digital ecosystem.",
                "Established in 2009 and headquartered in Lucknow, we are a BSE-listed company delivering innovative, reliable and scalable technology solutions across India. Backed by 40+ leading technology partners and a team of 150+ professionals, we serve clients across government, enterprise and public sector with end-to-end IT solutions.",
                "With 15+ years of proven delivery excellence, CMMI Level 3 appraisal, and over 1,000 projects delivered nationwide, we deliver turnkey solutions from consulting, design, and SITC to multi-year operations and maintenance."
            },
            CoreValues = new List<ValueItem>
            {
                new() { Title = "Clients First", Description = "Customer-centric products and services aligned with client requirements.", Icon = "bi-person-heart" },
                new() { Title = "Quality", Description = "Providing quality is our foremost priority across all deployments.", Icon = "bi-award" },
                new() { Title = "Accountability", Description = "We deliver what we commit with complete transparency and ownership.", Icon = "bi-check2-circle" },
                new() { Title = "Integrity", Description = "We deliver more than we promise instead of promising more.", Icon = "bi-shield-check" },
                new() { Title = "Association", Description = "We deliver with the view of long-term sustainable relationships.", Icon = "bi-people" },
                new() { Title = "Innovation", Description = "We embrace change and leverage technology for smarter, future-ready solutions.", Icon = "bi-lightbulb" },
                new() { Title = "Responsibility", Description = "Responsible towards clients, our people, environment, and communities.", Icon = "bi-globe" },
                new() { Title = "Excellence", Description = "Committed to delivering the highest quality in solutions, services, and support.", Icon = "bi-stars" }
            },
            Milestones = new List<CompanyMilestone>
            {
                new() { Year = "2009", Title = "The Beginning", Description = "Takyon Networks Limited was founded with a vision to deliver reliable and innovative IT solutions." },
                new() { Year = "2012", Title = "Building Foundation", Description = "Strengthened our capabilities and built a strong foundation of trust with government and corporate clients." },
                new() { Year = "2015", Title = "Strategic Growth", Description = "Formed strategic OEM partnerships and enhanced our service offerings." },
                new() { Year = "2018", Title = "Pan-India Expansion", Description = "Expanded presence across major cities and diversified across healthcare, railways, and enterprise verticals." },
                new() { Year = "2021", Title = "Scaling New Heights", Description = "Expanded teams, processes, and solutions to deliver state-wide wide area network and data center projects." },
                new() { Year = "2023", Title = "CMMI Level 3 Appraised", Description = "Achieved CMMI Level 3 appraisal strengthening process maturity and delivery excellence." },
                new() { Year = "2025", Title = "BSE Listed Milestone", Description = "Achieved a major corporate milestone by getting listed on the Bombay Stock Exchange (BSE)." },
                new() { Year = "2026", Title = "Future Ready", Description = "Continuing our journey towards sustainable innovation, advanced cloud architectures, and nationwide digital infrastructure." }
            },
            Empanelments = new List<EmpanelmentItem>
            {
                new() { Name = "UPDESCO", Description = "Empaneled for state IT infrastructure and turnkey system integration." },
                new() { Name = "UPPCL", Description = "Empaneled vendor for power utility IT, networking, and data infrastructure." },
                new() { Name = "GeM Portal", Description = "Registered on Government e-Marketplace for direct procurement by Central & State bodies." },
                new() { Name = "RailTel", Description = "Empaneled for railway telecommunications, networking, and surveillance projects." },
                new() { Name = "UPRNN", Description = "Empaneled for infrastructure modernization and institutional IT deployments." }
            }
        };

        _leadership = new List<LeadershipMemberViewModel>
        {
            new()
            {
                Name = "Manish Sharma",
                Title = "Managing Director",
                RoleCategory = "Executive Leadership",
                Bio = "Visionary leader with a passion for technology and innovation. He drives the company’s corporate strategy, market expansion, and long-term sustainable growth.",
                ImagePath = "/images/leadership/manish-sharma.jpg",
                DisplayOrder = 1
            },
            new()
            {
                Name = "Neeraj Kumar",
                Title = "Chief Executive Officer (CEO)",
                RoleCategory = "Executive Leadership",
                Bio = "Operations and delivery expert focused on building high-performance teams, operational excellence, and delivering complex client value at scale.",
                ImagePath = "/images/leadership/neeraj-kumar.jpg",
                DisplayOrder = 2
            },
            new()
            {
                Name = "Nikhil Buran",
                Title = "Director of Sales",
                RoleCategory = "Business & Sales",
                Bio = "Sales leader with proven expertise in enterprise solution selling, strategic account management, and driving nationwide business growth.",
                ImagePath = "/images/leadership/nikhil-buran.jpg",
                DisplayOrder = 3
            },
            new()
            {
                Name = "Paresh Goyal",
                Title = "Executive Director",
                RoleCategory = "Executive Leadership",
                Bio = "Technology strategist with deep industry experience across infrastructure and telecommunications. He leads strategic initiatives and drives technical excellence.",
                ImagePath = "/images/leadership/paresh-goyal.jpg",
                DisplayOrder = 4
            },
            new()
            {
                Name = "Rahul Patwa",
                Title = "Chief Technology Officer (CTO)",
                RoleCategory = "Technology Leadership",
                Bio = "A highly motivated technology leader with expertise in pre-sales, solution architecture, and systems engineering. He ensures seamless execution and client satisfaction.",
                ImagePath = "/images/leadership/rahul-patwa.jpg",
                DisplayOrder = 5
            },
            new()
            {
                Name = "Vivek Singh",
                Title = "Chief Financial Officer (CFO)",
                RoleCategory = "Finance & Governance",
                Bio = "Chartered Accountant with expertise in corporate finance, capital allocation, and credit underwriting. He leads financial strategy, SEBI/BSE compliance, and sustainable growth.",
                ImagePath = "/images/leadership/vivek-singh.jpg",
                DisplayOrder = 6
            }
        };

        _solutions = new List<SolutionItemViewModel>
        {
            // --- The 6 Primary Core IT Solutions (A4 Brochure p.4) ---
            new()
            {
                Id = "enterprise-networking",
                Title = "Enterprise Networking",
                Category = "Core IT Solution",
                IsCoreBrochureSolution = true,
                Summary = "High-performance wired and wireless networking solutions ensuring seamless connectivity, high availability, and operational resilience across distributed campuses.",
                Icon = "bi-diagram-3",
                DisplayOrder = 1,
                SubServices = new List<string> { "Structured Cabling", "LAN & WAN Infrastructure", "SD-WAN Solutions", "Enterprise Wi-Fi" },
                KeyHighlights = new List<string> { "High Performance & Reliability", "Scalable Multi-tier Architectures", "Built-in Security Controls", "Centralized Network Monitoring" },
                WhyItMatters = new List<string> { "Seamless connectivity across geographically dispersed offices", "Optimized application response times and zero-lag communications", "Reduced network downtime through automated failover", "Modern infrastructure engineered for future bandwidth scaling" }
            },
            new()
            {
                Id = "cyber-security",
                Title = "Cyber Security",
                Category = "Core IT Solution",
                IsCoreBrochureSolution = true,
                Summary = "Advanced multi-layered cyber security architectures engineered to protect sensitive organizational data, users, and critical infrastructure from evolving cyber threats.",
                Icon = "bi-shield-lock",
                DisplayOrder = 2,
                SubServices = new List<string> { "Network Security", "Endpoint Protection", "Data Security", "Web Application Security" },
                KeyHighlights = new List<string> { "Next-Gen Firewalls & UTM", "Data Loss Prevention (DLP)", "Identity & Access Management (IAM)", "Continuous Threat Monitoring" },
                WhyItMatters = new List<string> { "Proactive isolation of emerging threat vectors before operational impact", "Compliance with national cybersecurity frameworks and regulatory guidelines", "Centralized identity governance across hybrid environments", "Resilient data loss prevention safeguards for institutional IP" }
            },
            new()
            {
                Id = "data-center",
                Title = "Data Center Solutions",
                Category = "Core IT Solution",
                IsCoreBrochureSolution = true,
                Summary = "Turnkey data center engineering from physical infrastructure and precision cooling to virtualization, storage consolidation, and disaster recovery readiness.",
                Icon = "bi-server",
                DisplayOrder = 3,
                SubServices = new List<string> { "Enterprise Data Centers", "Virtualization Solution", "High Availability", "Disaster Recovery" },
                KeyHighlights = new List<string> { "Robust DC Infrastructure", "Precision Power & Cooling Efficiency", "Physical & Perimeter Security", "Data Center Modernization" },
                WhyItMatters = new List<string> { "Guarantees high availability for mission-critical applications", "Optimizes power usage effectiveness (PUE) and operational expenditure", "Safeguards physical server assets with multi-tier access controls", "Enables rapid disaster recovery and business continuity failover" }
            },
            new()
            {
                Id = "cloud-solutions",
                Title = "Cloud Solutions",
                Category = "Core IT Solution",
                IsCoreBrochureSolution = true,
                Summary = "Secure cloud migration, hybrid cloud architecture, automated backups, and 24/7 managed infrastructure services to empower enterprise agility.",
                Icon = "bi-cloud-check",
                DisplayOrder = 4,
                SubServices = new List<string> { "Cloud Infrastructure", "Migration Services", "Backup & Recovery", "Cloud Management" },
                KeyHighlights = new List<string> { "Seamless Cloud Migration", "Flexible Hybrid Architecture", "Proactive Managed Services", "Automated Disaster Recovery" },
                WhyItMatters = new List<string> { "Frictionless workload transitions with zero disruption to daily services", "Dynamic scaling matching real-time compute demand", "Reduced on-premises CAPEX in favor of efficient OPEX models", "Continuous 24/7 infrastructure observability and management" }
            },
            new()
            {
                Id = "security-surveillance",
                Title = "Security & Surveillance",
                Category = "Core IT Solution",
                IsCoreBrochureSolution = true,
                Summary = "Integrated smart physical security and IP video surveillance systems for campus safety, perimeter security, command center monitoring, and automated threat alerts.",
                Icon = "bi-camera-video",
                DisplayOrder = 5,
                SubServices = new List<string> { "IP Video Surveillance", "Access Control Solutions", "Intrusion Detection", "Monitoring & Maintenance" },
                KeyHighlights = new List<string> { "360° Security Visibility", "Multi-layered Perimeter Protection", "Proactive Threat Awareness", "Centralized Command & Control" },
                WhyItMatters = new List<string> { "Unified real-time visibility across complex industrial and institutional premises", "Automated intrusion detection preventing perimeter compromises", "Audit-ready access logs and tamper-resistant digital video retention", "Single pane of glass operations for security response teams" }
            },
            new()
            {
                Id = "av-collaboration",
                Title = "AV & Collaboration Services",
                Category = "Core IT Solution",
                IsCoreBrochureSolution = true,
                Summary = "Smart audiovisual environments, unified conferencing spaces, interactive displays, and connected smart classrooms designed for frictionless collaboration.",
                Icon = "bi-display",
                DisplayOrder = 6,
                SubServices = new List<string> { "Video Conferencing", "Unified Communications", "Interactive Display", "Smart Classrooms" },
                KeyHighlights = new List<string> { "High-Definition Audio & Visuals", "Seamless Hybrid Integration", "User-Friendly Touch Interfaces", "Scalable Enterprise Deployment" },
                WhyItMatters = new List<string> { "Empowers distributed hybrid teams with lifelike meeting experiences", "Enhances interactive student engagement in modern education campuses", "Accelerates institutional decision-making and cross-team execution", "Standardized meeting room technology requiring minimal user training" }
            },

            // --- Additional Specialized Service Categories (Company Profile p.11, 14, 19) ---
            new()
            {
                Id = "sdwan-solutions",
                Title = "SD-WAN & WAN Solutions",
                Category = "Specialized Service",
                IsCoreBrochureSolution = false,
                Summary = "Software-defined wide area network architectures delivering dynamic application routing, link bonding, MPLS cost reduction, and multi-site orchestration.",
                Icon = "bi-hdd-network",
                DisplayOrder = 7,
                SubServices = new List<string> { "Multi-Site Connectivity", "WAN Optimization", "Secure WAN Connectivity", "Centralized Orchestration", "Cloud On-Ramping" },
                KeyHighlights = new List<string> { "Intelligent Path Selection", "Cost Optimization over MPLS", "Zero-Touch Branch Deployment", "Application-Aware Priority Routing" },
                WhyItMatters = new List<string> { "Ensures critical ERP and SaaS traffic receives priority over general data", "Reduces recurring telecommunications bandwidth expenses", "Provides centralized policy administration across hundreds of branch offices", "Built-in cryptographic tunnels safeguarding inter-branch traffic" }
            },
            new()
            {
                Id = "drone-solutions",
                Title = "Drone-Enabled Solutions",
                Category = "Specialized Service",
                IsCoreBrochureSolution = false,
                Summary = "High-resolution aerial surveillance, industrial site progress tracking, safety compliance inspection, and GIS mapping for large infrastructure projects.",
                Icon = "bi-broadcast-pin",
                DisplayOrder = 8,
                SubServices = new List<string> { "Structural Inspection", "Construction Progress Audits", "Infrastructure Monitoring", "Safety & Compliance Visual Data", "Aerial GIS Mapping" },
                KeyHighlights = new List<string> { "High-Resolution Aerial Imagery", "Efficient Remote Data Collection", "Reduced Manual Site Visits", "Consistent Visual Time-Series Documentation" },
                WhyItMatters = new List<string> { "Replaces hazardous manual tower/bridge climbing with safe aerial imaging", "Accelerates milestone billing audits for large highway and civil projects", "Delivers millimeter-accurate orthomosaic maps for engineering review", "Provides objective photographic audit records for project stakeholders" }
            },
            new()
            {
                Id = "software-solutions",
                Title = "Customized Software Solutions",
                Category = "Specialized Service",
                IsCoreBrochureSolution = false,
                Summary = "Tailored enterprise software workflows, systems integration middleware, portal development, and automation tools designed to optimize operational efficiency.",
                Icon = "bi-code-slash",
                DisplayOrder = 9,
                SubServices = new List<string> { "Enterprise Workflow Automation", "Custom Database Applications", "System Integration Middleware", "Institutional Portals" },
                KeyHighlights = new List<string> { "Tailored Business Logic", "Direct Integration with Network Hardware", "Role-Based Secure Portals", "Responsive Web Interfaces" },
                WhyItMatters = new List<string> { "Bridges disparate hardware systems with actionable reporting software", "Eliminates repetitive manual paperwork across administrative operations", "Ensures compliance with institutional governance and audit trails", "Built to scale alongside the organization's evolving digital landscape" }
            }
        };

        _industries = new List<IndustryVerticalViewModel>
        {
            new()
            {
                Id = "government-psu",
                Name = "Government & Public Sector",
                Description = "Secure, compliant, and scalable digital infrastructure solutions empowering government secretariats, public agencies, and state-wide administrative networks.",
                Icon = "bi-bank",
                FocusAreas = new List<string> { "State Wide Area Networks (SWAN)", "Direct GeM Procurement", "Data Center Modernization", "Campus Surveillance" },
                DisplayOrder = 1
            },
            new()
            {
                Id = "railways",
                Name = "Railways & Transportation",
                Description = "Design, supply, SITC, and mission-critical AMC of network architectures, IP exchanges, and optical connectivity compliant with RDSO standards.",
                Icon = "bi-train-front",
                FocusAreas = new List<string> { "RDSO Specification Conformance", "Asterisk IP Exchange AMC", "Divisional Railway HQ Networking", "RTO Transport IT" },
                DisplayOrder = 2
            },
            new()
            {
                Id = "defence",
                Name = "Defence & Mission-Critical",
                Description = "High-security network deployments, VSAT hub connectivity, and secure surveillance infrastructure with stringent compliance and highest security clearances.",
                Icon = "bi-shield-shaded",
                FocusAreas = new List<string> { "VSAT Remote Hub Connectivity", "HAL Avionics Plant Infrastructure", "Army Command Network Security", "Zero-Failure Operations" },
                DisplayOrder = 3
            },
            new()
            {
                Id = "education",
                Name = "Education & Research",
                Description = "High-density campus Wi-Fi, optical backbones, smart classrooms, and digital lab infrastructure powering premier universities and institutes.",
                Icon = "bi-mortarboard",
                FocusAreas = new List<string> { "IIT Campus Network Modernization", "RUSA Higher Education IT", "Interactive Learning Spaces", "High-Throughput Research LANs" },
                DisplayOrder = 4
            },
            new()
            {
                Id = "healthcare",
                Name = "Healthcare & Hospitals",
                Description = "Connected healthcare ecosystems, telemedicine connectivity, and reliable hospital management network backbones operating 24/7 without interruption.",
                Icon = "bi-hospital",
                FocusAreas = new List<string> { "AIIMS Multi-Building Campus LANs", "National Health Mission (NHM) IT", "Hospital FMS Support", "Zero-Downtime Reliability" },
                DisplayOrder = 5
            },
            new()
            {
                Id = "bfsi",
                Name = "Banking, Financial Services & Insurance",
                Description = "Highly secure, low-latency, and compliance-ready network infrastructure supporting branch connectivity, core banking systems, and financial data integrity.",
                Icon = "bi-cash-coin",
                FocusAreas = new List<string> { "NABARD & Bank of Baroda Connectivity", "Gramin Bank Branch Integration", "Layered Network Security", "SEBI & RBI Compliance" },
                DisplayOrder = 6
            },
            new()
            {
                Id = "power-utilities",
                Name = "Power Generation & Utilities",
                Description = "Multi-location plant LAN connectivity, load dispatch networking, and industrial IT infrastructure supporting reliable energy generation and transmission.",
                Icon = "bi-lightning-charge",
                FocusAreas = new List<string> { "MPPGCL 19 Power Plant LANs", "NTPC Corporate Network Support", "HPSLDC Load Despatch Center", "Substation Redundancy" },
                DisplayOrder = 7
            },
            new()
            {
                Id = "enterprise-corporate",
                Name = "Corporate & Enterprise",
                Description = "End-to-end enterprise IT solutions driving seamless collaboration, cloud migration, SD-WAN cost optimization, and secure hybrid workforce mobility.",
                Icon = "bi-buildings",
                FocusAreas = new List<string> { "Corporate Headquarters Wi-Fi 6", "Hybrid Cloud Migration", "Unified Video Collaboration", "Managed Security Services" },
                DisplayOrder = 8
            },
            new()
            {
                Id = "telecom",
                Name = "Telecom & Communication",
                Description = "High-performance backbone infrastructure, optical transmission, and carrier-grade equipment integration keeping telecommunications networks always connected.",
                Icon = "bi-broadcast",
                FocusAreas = new List<string> { "Carrier Routing & Switching", "Optical Fiber Infrastructure", "NMS Network Monitoring", "Disaster Recovery Linkages" },
                DisplayOrder = 9
            },
            new()
            {
                Id = "manufacturing",
                Name = "Manufacturing & Industry",
                Description = "Ruggedized industrial networking, shop-floor IoT connectivity, perimeter video surveillance, and drone-assisted facility monitoring.",
                Icon = "bi-gear-wide-connected",
                FocusAreas = new List<string> { "Industrial Ethernet Solutions", "Drone Progress Audits", "Automated Perimeter Safety", "OT & IT Network Segmentation" },
                DisplayOrder = 10
            },
            new()
            {
                Id = "hospitality",
                Name = "Hospitality",
                Description = "High-capacity guest Wi-Fi, integrated IP television, building access controls, and unified communication systems delivering frictionless guest experiences.",
                Icon = "bi-cup-hot",
                FocusAreas = new List<string> { "Guest Portal & Bandwidth Shaping", "Integrated CCTV Surveillance", "Centralized VoIP PBX", "Property Management IT" },
                DisplayOrder = 11
            },
            new()
            {
                Id = "media",
                Name = "Media & Broadcasting",
                Description = "Ultra-high bandwidth networks, media asset storage, low-latency video streaming backbones, and studio collaboration facilities.",
                Icon = "bi-camera-reels",
                FocusAreas = new List<string> { "Low-Latency Live Streaming", "High-Throughput SAN Storage", "Studio AV Systems Integration", "Secure Digital Asset Archiving" },
                DisplayOrder = 12
            }
        };

        _projects = new List<ProjectCaseStudyViewModel>
        {
            new()
            {
                Id = "aiims-bibinagar",
                ProjectNumber = "01",
                Title = "AIIMS Bibinagar Campus Networking",
                Client = "NCC Limited (for AIIMS Bibinagar, Telangana)",
                Location = "Bibinagar, Telangana",
                Scope = "Supply, Installation, Testing, and Commissioning (SITC) of high-speed campus networking infrastructure across 23 institutional and medical buildings.",
                Industry = "Healthcare & Education",
                ImagePath = "/images/projects/aiims-bibinagar.jpg",
                IsFeaturedOnHome = true,
                DisplayOrder = 1
            },
            new()
            {
                Id = "rdso-telecom",
                ProjectNumber = "02",
                Title = "RDSO Telecom Infrastructure, Lucknow",
                Client = "Research Designs & Standards Organisation (RDSO), Ministry of Railways",
                Location = "Manaknagar, Lucknow, Uttar Pradesh",
                Scope = "Comprehensive Annual Maintenance Contract (AMC) of Asterisk-based IP Exchange system along with SITC of specialized railway telecommunication items.",
                Industry = "Railways & Transportation",
                ImagePath = "/images/projects/rdso-telecom.jpg",
                IsFeaturedOnHome = true,
                DisplayOrder = 2
            },
            new()
            {
                Id = "eastern-command-army",
                ProjectNumber = "03",
                Title = "Eastern Command, Indian Army",
                Client = "ECMS, Kolkata",
                Location = "Kolkata & Eastern Sector",
                Scope = "Establishment of remote location to main hub connectivity utilizing high-reliability VSAT Network infrastructure for mission-critical operations.",
                Industry = "Defence & Mission-Critical",
                ImagePath = "/images/projects/eastern-command-army.jpg",
                IsFeaturedOnHome = true,
                DisplayOrder = 3
            },
            new()
            {
                Id = "upswan",
                ProjectNumber = "04",
                Title = "UPSWAN 2.0 State Wide Area Network",
                Client = "Government of Uttar Pradesh",
                Location = "Uttar Pradesh (State-wide)",
                Scope = "Facility Management Services (FMS), end-to-end design, implementation, and multi-year Operation & Maintenance of UPSWAN 2.0 across all district headquarters.",
                Industry = "Government & Public Sector",
                ImagePath = "/images/projects/upswan.jpg",
                IsFeaturedOnHome = true,
                DisplayOrder = 4
            },
            new()
            {
                Id = "bihar-swan",
                ProjectNumber = "05",
                Title = "Bihar SWAN Wide Area Network",
                Client = "Government of Bihar",
                Location = "Bihar (State-wide)",
                Scope = "Annual Operations & Maintenance (O&M) of Bihar SWAN Wide Area Network ensuring continuous government digital connectivity and service delivery.",
                Industry = "Government & Public Sector",
                ImagePath = "/images/projects/bihar-swan.jpg",
                IsFeaturedOnHome = true,
                DisplayOrder = 5
            },
            new()
            {
                Id = "mppgcl-power-plants",
                ProjectNumber = "06",
                Title = "MPPGCL Multi-Location LAN Infrastructure",
                Client = "Madhya Pradesh Power Generating Company Limited (MPPGCL)",
                Location = "Madhya Pradesh (State-wide)",
                Scope = "Design, supply, installation, testing, commissioning, and Operation & Maintenance of robust LAN solutions across 19 thermal and hydel power plants in Madhya Pradesh.",
                Industry = "Power & Utilities",
                ImagePath = "/images/projects/mppgcl-power-plants.jpg",
                IsFeaturedOnHome = true,
                DisplayOrder = 6
            },
            new()
            {
                Id = "hal-lucknow",
                ProjectNumber = "07",
                Title = "Hindustan Aeronautics Limited (HAL), Lucknow",
                Client = "Hindustan Aeronautics Limited",
                Location = "Lucknow, Uttar Pradesh",
                Scope = "Execution of core network migration and implementation of enterprise Network Management System (NMS) to enhance real-time monitoring across LAN and WAN networks.",
                Industry = "Defence & Aerospace",
                ImagePath = "/images/projects/hal-lucknow.jpg",
                IsFeaturedOnHome = false,
                DisplayOrder = 7
            },
            new()
            {
                Id = "aiims-guwahati",
                ProjectNumber = "08",
                Title = "AIIMS Guwahati IT Infrastructure Maintenance",
                Client = "NCC Limited (for AIIMS Guwahati, Assam)",
                Location = "Guwahati, Assam",
                Scope = "Comprehensive maintenance, troubleshooting, and 24/7 technical support of entire campus IT infrastructure to ensure uninterrupted clinical and academic operations.",
                Industry = "Healthcare & Education",
                ImagePath = "/images/projects/aiims-guwahati.jpg",
                IsFeaturedOnHome = false,
                DisplayOrder = 8
            },
            new()
            {
                Id = "nic-ddos",
                ProjectNumber = "09",
                Title = "NIC Services Router Installation & AMC",
                Client = "National Informatics Centre Services Inc (NICSI), New Delhi",
                Location = "New Delhi",
                Scope = "Installation, configuration, and comprehensive AMC support of high-capacity edge routers ensuring uninterrupted connectivity and DDoS mitigation support.",
                Industry = "Government & Public Sector",
                ImagePath = "/images/projects/nic-ddos.jpg",
                IsFeaturedOnHome = false,
                DisplayOrder = 9
            }
        };

        _clients = new List<ClientLogoViewModel>
        {
            new() { Name = "Indian Army Eastern Command", Sector = "Defence", LogoPath = "/images/clients/indian-army.jpg", AltText = "Indian Army Eastern Command Logo", Description = "Defence VSAT and network infrastructure" },
            new() { Name = "NABARD", Sector = "BFSI", LogoPath = "/images/clients/nabard.jpg", AltText = "NABARD National Bank for Agriculture and Rural Development Logo", Description = "Financial institution network support" },
            new() { Name = "Bank of Baroda", Sector = "BFSI", LogoPath = "/images/clients/bank-of-baroda.jpg", AltText = "Bank of Baroda Logo", Description = "Enterprise digital banking connectivity" },
            new() { Name = "IIT Kanpur", Sector = "Education", LogoPath = "/images/clients/iit-kanpur.jpg", AltText = "Indian Institute of Technology Kanpur Logo", Description = "Premier academic campus networking" },
            new() { Name = "Uttar Pradesh Gramin Bank", Sector = "BFSI", LogoPath = "/images/clients/up-gramin-bank.jpg", AltText = "Uttar Pradesh Gramin Bank Logo", Description = "Rural banking branch network integration" },
            new() { Name = "MPPGCL", Sector = "Power & Utilities", LogoPath = "/images/clients/mppgcl.jpg", AltText = "Madhya Pradesh Power Generating Company Limited Logo", Description = "19 thermal/hydel power plant LAN infrastructure" },
            new() { Name = "RDSO (Ministry of Railways)", Sector = "Railways", LogoPath = "/images/clients/rdso.jpg", AltText = "Research Designs and Standards Organisation Logo", Description = "Railway telecommunication and IP exchange AMC" },
            new() { Name = "Rajendra Singh University", Sector = "Education", LogoPath = "/images/clients/rajendra-singh-university.jpg", AltText = "Rajendra Singh University Logo", Description = "University campus network deployment" },
            new() { Name = "Punjab & Sind Bank", Sector = "BFSI", LogoPath = "/images/clients/punjab-and-sind-bank.jpg", AltText = "Punjab and Sind Bank Logo", Description = "Banking IT infrastructure and security" },
            new() { Name = "AIIMS", Sector = "Healthcare", LogoPath = "/images/clients/aiims.jpg", AltText = "All India Institute of Medical Sciences Logo", Description = "Multi-building medical campus network and FMS" },
            new() { Name = "North Central Railway, Jhansi", Sector = "Railways", LogoPath = "/images/clients/ncr-jhansi.jpg", AltText = "North Central Railway Jhansi Logo", Description = "Railway division IT and network solutions" },
            new() { Name = "RTO Uttar Pradesh", Sector = "Government", LogoPath = "/images/clients/rto-up.jpg", AltText = "Regional Transport Office Uttar Pradesh Logo", Description = "Transport department state-wide networking" },
            new() { Name = "HPSLDC", Sector = "Power & Utilities", LogoPath = "/images/clients/hpsldc.jpg", AltText = "Himachal Pradesh State Load Despatch Center Logo", Description = "Power grid load management IT infrastructure" },
            new() { Name = "UPEIDA", Sector = "Government", LogoPath = "/images/clients/upeida.jpg", AltText = "UP Expressway Industrial Development Authority Logo", Description = "Industrial corridor IT and connectivity" },
            new() { Name = "North Central Railway, Agra", Sector = "Railways", LogoPath = "/images/clients/ncr-agra.jpg", AltText = "North Central Railway Agra Logo", Description = "Railway division network infrastructure" },
            new() { Name = "Hindustan Aeronautics Limited (HAL)", Sector = "Defence", LogoPath = "/images/clients/hal.jpg", AltText = "Hindustan Aeronautics Limited Logo", Description = "Avionics plant core network migration & NMS" },
            new() { Name = "NTPC Limited", Sector = "Power & Utilities", LogoPath = "/images/clients/ntpc.jpg", AltText = "National Thermal Power Corporation Logo", Description = "Power generation facility network infrastructure" },
            new() { Name = "National Health Mission (NHM)", Sector = "Healthcare", LogoPath = "/images/clients/nhm.jpg", AltText = "National Health Mission Logo", Description = "State & district healthcare network infrastructure" },
            new() { Name = "RUSA", Sector = "Education", LogoPath = "/images/clients/rusa.jpg", AltText = "Rashtriya Uchchatar Shiksha Abhiyan Logo", Description = "Higher education digital infrastructure deployment" },
            new() { Name = "District Hospital", Sector = "Healthcare", LogoPath = "/images/clients/district-hospital.jpg", AltText = "District Hospital Health Services Logo", Description = "District hospital patient care digital network" }
        };

        _partners = new List<PartnerLogoViewModel>
        {
            new() { Name = "Dell", Category = "OEM Partner", LogoPath = "/images/partners/dell.png", AltText = "Dell Technologies", IsFeatured = true },
            new() { Name = "APC by Schneider", Category = "Power & Rack Infrastructure", LogoPath = "/images/partners/apc.png", AltText = "APC by Schneider Electric", IsFeatured = true },
            new() { Name = "Arista Networks", Category = "Data Center Networking", LogoPath = "/images/partners/arista.png", AltText = "Arista Networks", IsFeatured = true },
            new() { Name = "Amazon Web Services (AWS)", Category = "Cloud Infrastructure", LogoPath = "/images/partners/aws.png", AltText = "Amazon Web Services", IsFeatured = true },
            new() { Name = "Bosch", Category = "Surveillance & Audio", LogoPath = "/images/partners/bosch.png", AltText = "Bosch Security", IsFeatured = true },
            new() { Name = "CommScope", Category = "Structured Cabling", LogoPath = "/images/partners/commscope.png", AltText = "CommScope", IsFeatured = true },
            new() { Name = "Check Point Software", Category = "Cyber Security", LogoPath = "/images/partners/checkpoint.png", AltText = "Check Point Software Technologies", IsFeatured = true },
            new() { Name = "Palo Alto Networks", Category = "Cyber Security", LogoPath = "/images/partners/paloalto.png", AltText = "Palo Alto Networks", IsFeatured = true },
            new() { Name = "Commvault", Category = "Data Protection & Backup", LogoPath = "/images/partners/commvault.png", AltText = "Commvault", IsFeatured = true },
            new() { Name = "Dell EMC", Category = "Enterprise Storage & Compute", LogoPath = "/images/partners/dellemc.png", AltText = "Dell EMC", IsFeatured = true },
            new() { Name = "Eaton", Category = "Power Quality & UPS", LogoPath = "/images/partners/eaton.png", AltText = "Eaton Power", IsFeatured = false },
            new() { Name = "Fortinet", Category = "Network Security", LogoPath = "/images/partners/fortinet.png", AltText = "Fortinet", IsFeatured = true },
            new() { Name = "Google Cloud", Category = "Cloud Platform", LogoPath = "/images/partners/googlecloud.png", AltText = "Google Cloud Platform", IsFeatured = true },
            new() { Name = "Honeywell", Category = "Building & Security Solutions", LogoPath = "/images/partners/honeywell.png", AltText = "Honeywell", IsFeatured = false },
            new() { Name = "Hitachi", Category = "Enterprise Storage & Systems", LogoPath = "/images/partners/hitachi.png", AltText = "Hitachi Vantara", IsFeatured = false },
            new() { Name = "Hewlett Packard Enterprise (HPE)", Category = "Compute & Hybrid IT", LogoPath = "/images/partners/hpe.png", AltText = "Hewlett Packard Enterprise", IsFeatured = true },
            new() { Name = "Juniper Networks", Category = "Enterprise Routing & Switching", LogoPath = "/images/partners/juniper.png", AltText = "Juniper Networks", IsFeatured = true },
            new() { Name = "Molex Connected Enterprise", Category = "Structured Cabling", LogoPath = "/images/partners/molex.png", AltText = "Molex", IsFeatured = false },
            new() { Name = "Microsoft", Category = "Enterprise Cloud & Software", LogoPath = "/images/partners/microsoft.png", AltText = "Microsoft Partner", IsFeatured = true },
            new() { Name = "NetApp", Category = "Hybrid Cloud Data Storage", LogoPath = "/images/partners/netapp.png", AltText = "NetApp", IsFeatured = true },
            new() { Name = "Ivanti", Category = "Unified Endpoint Management", LogoPath = "/images/partners/ivanti.png", AltText = "Ivanti", IsFeatured = false },
            new() { Name = "Poly (HP)", Category = "Unified Communications", LogoPath = "/images/partners/poly.png", AltText = "Poly Video Collaboration", IsFeatured = false },
            new() { Name = "Radware", Category = "DDoS & Application Delivery", LogoPath = "/images/partners/radware.png", AltText = "Radware", IsFeatured = false },
            new() { Name = "Red Hat", Category = "Enterprise Open Source", LogoPath = "/images/partners/redhat.png", AltText = "Red Hat", IsFeatured = true },
            new() { Name = "Ruckus Networks", Category = "Wireless & Switching", LogoPath = "/images/partners/ruckus.png", AltText = "Ruckus Networks", IsFeatured = false },
            new() { Name = "Sophos", Category = "Endpoint & Network Security", LogoPath = "/images/partners/sophos.png", AltText = "Sophos", IsFeatured = true },
            new() { Name = "Trend Micro", Category = "Cloud Security", LogoPath = "/images/partners/trendmicro.png", AltText = "Trend Micro", IsFeatured = false },
            new() { Name = "VMware by Broadcom", Category = "Virtualization & Cloud", LogoPath = "/images/partners/vmware.png", AltText = "VMware", IsFeatured = true }
        };

        _offices = new List<OfficeContactViewModel>
        {
            new()
            {
                OfficeType = "Corporate Headquarters",
                City = "Lucknow",
                Address = "CP-37, Viraj Khand-4, Gomti Nagar, Lucknow - 226010, Uttar Pradesh, India",
                Phone = "(0522) 665 6617",
                Email = "info@takyon.co.in",
                IsAddressVerified = true,
                UnresolvedNote = null
            },
            new()
            {
                OfficeType = "Regional Office — Delhi NCR",
                City = "New Delhi",
                Address = "Delhi Office Address Withheld Pending Source Confirmation",
                Phone = "(011) 4560 5725",
                Email = "info@takyon.co.in",
                IsAddressVerified = false,
                UnresolvedNote = "The source documents contain conflicting addresses for the Delhi office (Company Profile p.29 lists '911, 9th Floor, DLF Jasola Vihar, New Delhi 110025'; A4 Brochure p.2 & p.8 lists '307, DLF Tower-B, Jasola District Center, New Delhi 110025'). In accordance with strict source-of-truth instructions, this address will remain unpublished until verified by stakeholders."
            },
            new()
            {
                OfficeType = "Branch Office — Eastern Region",
                City = "Kolkata",
                Address = "Unit No. 11, 4th Floor, Convergence Contact Centre, D2/2, EP GP Block, Sector V, Salt Lake, Kolkata - 700091, West Bengal, India",
                Phone = "Contact via Headquarters",
                Email = "info@takyon.co.in",
                IsAddressVerified = true,
                UnresolvedNote = null
            }
        };

        _discrepancies = new List<string>
        {
            "Service Taxonomy: Brochure p.4 establishes 6 Core IT Solutions (Enterprise Networking, Cyber Security, Data Center, Cloud Solutions, Security & Surveillance, AV & Collaboration). Company Profile expands SD-WAN into a standalone page, and adds Drone-Enabled Solutions and Software Solutions. Handled cleanly by modeling the 6 core pillars while separately presenting the profile's specialized categories.",
            "Delhi Office Address: Company Profile p.29 lists '911, 9th Floor, DLF Jasola Vihar, New Delhi 110025' while Brochure p.2 & p.8 lists '307, DLF Tower-B, Jasola District Center, New Delhi 110025'. In accordance with instructions, Delhi address is withheld from publication until verified.",
            "Lucknow HQ Phone: Company Profile p.29 lists '(022) 665 6617' (Mumbai 022 STD code) while Brochure p.2 & p.8 lists '(0522) 665 6617' (Lucknow 0522 STD code). The correct Lucknow code (0522) is used in mock data.",
            "Contact QR Payload: Brochure p.8 shows two static QR codes for 'Website' and 'Company Profile'. Dynamic QR code generation is withheld until the target payload structure (URL, vCard, or download link) is confirmed."
        };
    }

    public CompanyOverviewViewModel GetCompanyOverview() => _overview;
    public IReadOnlyList<LeadershipMemberViewModel> GetLeadershipTeam() => _leadership;
    public IReadOnlyList<SolutionItemViewModel> GetSolutions(bool coreOnly = false) => 
        coreOnly ? _solutions.Where(s => s.IsCoreBrochureSolution).OrderBy(s => s.DisplayOrder).ToList() : _solutions.OrderBy(s => s.DisplayOrder).ToList();
    public SolutionItemViewModel? GetSolutionById(string id) => _solutions.FirstOrDefault(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
    public IReadOnlyList<IndustryVerticalViewModel> GetIndustries() => _industries.OrderBy(i => i.DisplayOrder).ToList();
    public IReadOnlyList<ProjectCaseStudyViewModel> GetProjects() => _projects.OrderBy(p => p.DisplayOrder).ToList();
    public IReadOnlyList<ClientLogoViewModel> GetClients() => _clients;
    public IReadOnlyList<PartnerLogoViewModel> GetPartners() => _partners;
    public IReadOnlyList<OfficeContactViewModel> GetOfficeContacts() => _offices;
    public IReadOnlyList<string> GetUnresolvedDiscrepancies() => _discrepancies;
}

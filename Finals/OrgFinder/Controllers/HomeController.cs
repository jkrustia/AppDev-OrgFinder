using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrgFinder.Models;

namespace OrgFinder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Sample data (replace with database or other data source)
        ViewBag.Departments = new List<string> { 
            "College of Accountancy and Finance (CAF)", 
            "College of Architecture, Design and the Built Environment (CADBE)", 
            "College of Arts and Letters (CAL)", 
            "College of Business Administration (CBA)",
            "College of Communication (COC)",
            "College of Computer and Information Sciences (CCIS)",
            "College of Education (COED)",
            "College of Engineering (CE)",
            "College of Human Kinetics (CHK)",
            "College of Political Science and Public Administration (CPSPA)",
            "College of Social Sciences and Development (CSSD)",
            "College of Science (CS)",
            "College of Tourism, Hospitality and Transportation Management (CTHTM)" };

        ViewBag.Programs = new Dictionary<string, List<string>>
        {
            { "College of Accountancy and Finance (CAF)", new List<string> 
                { 
                    "Bachelor of Science in Accountancy (BSA)", 
                    "Bachelor of Science in Business Administration Major in Financial Management (BSBAFM)", 
                    "Bachelor of Science in Management Accounting (BSMA)" } },
            
            { "College of Architecture, Design and the Built Environment (CADBE)", new List<string> 
                { 
                    "Bachelor of Science in Architecture (BS-ARCH)", 
                    "Bachelor of Science in Environmental Planning (BSEP)" } },

            { "College of Arts and Letters (CAL)", new List<string> 
                { 
                    "Bachelor of Arts in English Language Studies (ABELS)", 
                    "Bachelor of Arts in Filipinology (ABF)", 
                    "Bachelor of Arts in Literary and Cultural Studies (ABLCS)",
                    "Bachelor of Arts in Philosophy (AB-PHILO)",
                    "Bachelor of Performing Arts major in Theater Arts (BPEA)" } },

            { "College of Business Administration (CBA)", new List<string> 
                { 
                    "Bachelor of Science in Business Administration major in Human Resource Management (BSBAHRM)", 
                    "Bachelor of Science in Business Administration major in Marketing Management (BSBA-MM)",
                    "Bachelor of Science in Entrepreneurship (BSENTREP)", 
                    "Bachelor of Science in Office Administration (BSOA)" } },

            { "College of Communication (COC)", new List<string> 
                { 
                    "Bachelor in Advertising and Public Relations (BADPR)", 
                    "Bachelor of Arts in Broadcasting (BA Broadcasting)", 
                    "Bachelor of Arts in Communication Research (BACR)",
                    "Bachelor of Arts in Journalism (BAJ)" } },

            { "College of Computer and Information Sciences (CCIS)", new List<string> 
                { 
                    "Bachelor of Science in Computer Science (BSCS)", 
                    "Bachelor of Science in Information Technology (BSIT)" } },

            { "College of Education (COED)", new List<string> 
                { 
                    "Bachelor of Technology and Livelihood Education (BTLEd)", 
                    "Bachelor of Library and Information Science (BLIS)", 
                    "Bachelor of Secondary Education (BSEd)",
                    "Bachelor of Elementary Education (BEEd)",
                    "Bachelor of Early Childhood Education (BECEd)" } },

            { "College of Engineering (CE)", new List<string> 
                { 
                    "Bachelor of Science in Civil Engineering (BSCE)", 
                    "Bachelor of Science in Computer Engineering (BSCpE)", 
                    "Bachelor of Science in Electrical Engineering (BSEE)",
                    "Bachelor of Science in Electronics Engineering (BSECE)",
                    "Bachelor of Science in Industrial Engineering (BSIE)",
                    "Bachelor of Science in Mechanical Engineering (BSME)",
                    "Bachelor of Science in Railway Engineering (BSRE)" } },

            { "College of Human Kinetics (CHK)", new List<string> 
                { 
                    "Bachelor of Physical Education (BPE)", 
                    "Bachelor of Science in Exercises and Sports (BSESS)" } },

            { "College of Political Science and Public Administration (CPSPA)", new List<string> 
                { 
                    "Bachelor of Arts in Political Science (BAPS)", 
                    "Bachelor of Arts in Political Economy (BAPE)", 
                    "Bachelor of Arts in International Studies (BAIS)",
                    "Bachelor of Public Administration (BPA)" } },

            { "College of Social Sciences and Development (CSSD)", new List<string> 
                { 
                    "Bachelor of Arts in History (BAH)", 
                    "Bachelor of Arts in Sociology (BAS)", 
                    "Bachelor of Science in Cooperatives (BSC)",
                    "Bachelor of Science in Economics (BSE)",
                    "Bachelor of Science in Psychology (BSPSY)" } },

            { "College of Science (CS)", new List<string> 
                { 
                    "Bachelor of Science Food Technology (BSFT)", 
                    "Bachelor of Science in Applied Mathematics (BSAPMATH)", 
                    "Bachelor of Science in Biology (BSBIO)",
                    "Bachelor of Science in Chemistry (BSCHEM)",
                    "Bachelor of Science in Mathematics (BSMATH)",
                    "Bachelor of Science in Nutrition and Dietetics (BSND)",
                    "Bachelor of Science in Physics (BSPHY)",
                    "Bachelor of Science in Statistics (BSSTAT)" } },

            { "College of Tourism, Hospitality and Transportation Management (CTHTM)", new List<string> 
                { 
                    "Bachelor of Science in Hospitality Management (BSHM)", 
                    "Bachelor of Science in Tourism Management (BSTM)", 
                    "Bachelor of Science in Transportation Management (BSTRM)" } }
            
        };

        ViewBag.Interests = new List<string> 
        {
            "Business", "Technology", "Science", "Engineering", "Humanities", 
            "Social Sciences", "Medicine", "Law", "Education", 
            "Arts & Crafts", "Music", "Writing", "Design", "Photography", "Dance",
            "Sports", "Travel", "Gaming", "Volunteering",  
            "Health & Wellness", "Nature", "Culture", "Social Issues", "Religion",
            "Research", "Innovation", "Leadership", "Community Building"
        };

        return View();
    }

    [HttpPost]  // Important: This must be a POST request since you're submitting a form
    public IActionResult Results(StudentProfile profile) // Correct: Receive the StudentProfile
    {
        // 1. Check if the profile is null (important for debugging):
        if (profile == null) 
        {
            // Log this or handle it appropriately.  This means the form data isn't reaching the action.
            return View(new List<Organization>()); // Return an empty list to avoid null exception in view
        }

        // Sample organization data (replace with your actual data)
        var organizations = new List<Organization> { 
            new Organization 
                { 
                    Name = "Advertising and Public Relations Organization of Students (ADPROS)", 
                    Website = "https://facebook.com/PUPADPROS",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Business", "Media" } },
            
            new Organization 
                { 
                    Name = "Agham Youth-Polytechnic University of the Philippines (AY-PUP)", 
                    Website = "https://facebook.com/aghamyouthPUP",
                    Interests = new List<string> { "Science", "Technology" } },

            new Organization 
                { 
                    Name = "Aksyon Verde", 
                    Interests = new List<string> { "Nature", "Social Issues", "Volunteering", "Community Building", "Environment" } },
            
            new Organization 
                { 
                    Name = "Alyansa ng mga Panulat na Sumusuong (ALPAS)", 
                    Website = "https://facebook.com/ALPASFilipinolohiya",
                    Department = "College of Arts and Letters (CAL)", 
                    Interests = new List<string> { "Writing" } },

            new Organization 
                { 
                    Name = "American Concrete Institute Philippines-Polytechnic University of the Philippines Student Chapter (ACIP-PUPSC)", 
                    Website = "https://facebook.com/acip.pupsc", 
                    Interests = new List<string> { "Engineering", "Innovation", "Research" } },

            new Organization 
                { 
                    Name = "ANGAT Iskolar PUP", 
                    Website = "https://facebook.com/angatiskolarpup", 
                    Interests = new List<string> { "Volunteering", "Community Building" } },
            
            new Organization 
                { 
                    Name = "Aspiring Women Architects of the Philippines - Polytechnic University of the Philippines (AWAP-PUP)", 
                    Website = "https://facebook.com/awap.pup",
                    Department = "College of Architecture, Design and the Built Environment (CADBE)", 
                    Interests = new List<string> { "Design", "Arts & Crafts" } },
                    
            new Organization 
                { 
                    Name = "Association of Concerned Computer Engineering Students for Service (ACCESS)", 
                    Website = "https://facebook.com/profile.php?id=61564762945828",
                    Department = "College of Engineering (CE)", 
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = "Association of Concerned Transportation Students (ACTS)", 
                    Website = "https://facebook.com/PUPACTS2324",
                    Department = "College of Tourism, Hospitality and Transportation Management (CTHTM)",  
                    Interests = new List<string> { "Travel", "Community Building" } },

            new Organization 
                { 
                    Name = "AWS Cloud Club - PUP Manila (AWSCC - PUP)", 
                    Website = "https://facebook.com/AWSCloudClubPUP", 
                    Interests = new List<string> { "Technology", "Innovation", "Science" } },

            new Organization 
                { 
                    Name = "Bachelor of Elementary and Secondary Teaching Society (BEST Society)", 
                    Website = "https://facebook.com/bestsociety.coedpup",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "Bachelor of Elementary Education Association (BEEDA)", 
                    Website = "https://facebook.com/beedacoedpup",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "Band of Young and Outstanding Bartenders (BYOB)", 
                    Website = "https://facebook.com/PUPByobManila", 
                    Interests = new List<string> { "Business", "Arts & Crafts" } },

            new Organization 
                { 
                    Name = "Bayanihan Youth for Peace - PUP Main Chapter (BYP - PUP)", 
                    Website = "https://facebook.com/byp.pup.mnl", 
                    Interests = new List<string> { "Volunteering", "Leadership", "Community Building", "Social Issues" } },
            
            new Organization 
                { 
                    Name = "Bukluran ng Progresibong Mag-aaral (BUKLURAN)", 
                    Website = "https://facebook.com/BukluranProgresibo", 
                    Interests = new List<string> { "Leadership", "Community Building" } },
            
            new Organization 
                { 
                    Name = "Center for Filipino Youth Volunteers - PUP (CFYV-PUP)", 
                    Website = "https://facebook.com/profile.php?id=61552092428386", 
                    Interests = new List<string> { "Volunteering", "Leadership", "Community Building", "Social Issues" } },

            new Organization 
                { 
                    Name = "Circle of Public Administration and Governance Students (CPAGS)", 
                    Website = "https://facebook.com/pupcpags",
                    Department = "College of Political Science and Public Administration (CPSPA)",  
                    Interests = new List<string> { "Social Sciences", "Law", "Leadership", "Research" } },
            
            new Organization 
                { 
                    Name = "CISCO NetConnect - PUP Manila (CNCPMNL)", 
                    Website = "https://facebook.com/profile.php?id=61564931946208",
                    Department = "College of Computer and Information Sciences (CCIS)",  
                    Interests = new List<string> { "Technology", "Innovation", "Science" } },
            
            new Organization 
                { 
                    Name = "Cru (CRU)", 
                    Website = "https://facebook.com/crupupofficial", 
                    Interests = new List<string> { "Culture", "Community Building", "Volunteering", "Religion" } },

            new Organization 
                { 
                    Name = "CTHTM Cerberus (CBR)", 
                    Website = "https://facebook.com/CTHTMCerberus",
                    Department = "College of Tourism, Hospitality and Transportation Management (CTHTM)",  
                    Interests = new List<string> { "Communiy Building", "Gaming" } },

            new Organization 
                { 
                    Name = "Damdamin at Malay PUP Sta.Mesa (DAMLAY PUP Sta.Mesa)", 
                    Website = "https://facebook.com/DamlayPupStaMesa",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education", "Volunteering", "Community Building", "Leadership" } },

            new Organization 
                { 
                    Name = "DZMC - Young Communications Guild (DZMC - YCG)", 
                    Website = "https://facebook.com/DZMCMascompleteOfficial",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Social Issues", "Writing", "Design", "Research" } },

            new Organization 
                { 
                    Name = "Entrepreneurial Students Society (ESS)", 
                    Website = "https://facebook.com/ESSPUP",
                    Department = "College of Business Administration (CBA)",  
                    Interests = new List<string> { "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "Environmental Planning Society (EPSoc)", 
                    Department = "College of Architecture, Design and the Built Environment (CADBE)",  
                    Interests = new List<string> { "Nature" } },
            
            new Organization 
                { 
                    Name = "Every Nation Campus Polytechnic Unversity of the Philippines (ENC PUP)", 
                    Website = "https://facebook.com/ENCampusPUP", 
                    Interests = new List<string> { "Leadership", "Religion" } },
            
            new Organization 
                { 
                    Name = "Exercise and Sports Science Association (ESSA)", 
                    Website = "https://facebook.com/PUPCHKESSA",
                    Department = "College of Human Kinetics (CHK)",  
                    Interests = new List<string> { "Sports", "Health & Wellness" } },

            new Organization 
                { 
                    Name = "Films Aficionados Circle (FILAC)", 
                    Website = "https://facebook.com/filmaficionadoscircle",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Writing", "Arts & Crafts", "Design", "Music", "Dance" } },

            
            new Organization 
                { 
                    Name = "For Adults Only Dance Crew (FAODC)", 
                    Website = "https://facebook.com/officialFAO", 
                    Interests = new List<string> { "Design", "Arts & Crafts", "Music", "Dance" } },

            new Organization 
                { 
                    Name = "Future Business Teachers' Organization (FBTO)", 
                    Website = "https://facebook.com/fbtopupmanila",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education", "Business" } },

            new Organization 
                { 
                    Name = "Gabriela Youth PUP", 
                    Website = "https://facebook.com/GabrielaYouthPUP", 
                    Interests = new List<string> { "Humanities", "Volunteering", "Leadership", "Social Issues", "Community Building" } },

            new Organization 
                { 
                    Name = "GDG on Campus Polytechnic University of the Philippines - Manila, Philippines (GDG PUP)", 
                    Website = "https://www.facebook.com/@gdg.pupmnl/",  
                    Interests = new List<string> { "Innovation", "Technology", "Science" } },
            
            new Organization 
                { 
                    Name = "Guild of English Majors (GEMs)", 
                    Website = "https://facebook.com/PUPGEMs",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "Guild of Livelihood and Technology Education Students (GLiTES)", 
                    Website = "https://facebook.com/Glitespup",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "Halawin (HWN)", 
                    Website = "https://facebook.com/sbshalawin",
                    Department = "College of Science (CS)",  
                    Interests = new List<string> { "Writing", "Arts & Crafts", "Design", "Leadership", "Volunteering" } },

            new Organization 
                { 
                    Name = "Harmonix - CTHTM (HMX-CTHTM)", 
                    Department = "College of Tourism, Hospitality and Transportation Management (CTHTM)",  
                    Interests = new List<string> { "Music" } },

            
            new Organization 
                { 
                    Name = "Hataw PUP (HPUP)", 
                    Website = "https://facebook.com/hataw.official", 
                    Interests = new List<string> { "Leadership", "Innovation", "Writing", "Volunteering" } },

            new Organization 
                { 
                    Name = "Hiyas ng Silangan Honors Society", 
                    Department = "College of Accountancy and Finance (CAF)",  
                    Interests = new List<string> { "Education", "Research", "Leadership", "Innovation" } },

            new Organization 
                { 
                    Name = "Hospitality Management Society", 
                    Website = "https://facebook.com/PUPManilaHMS",
                    Department = "College of Tourism, Hospitality and Transportation Management (CTHTM)",  
                    Interests = new List<string> { "Business", "Education", "Culture" } },

            new Organization 
                { 
                    Name = "Human Resource Students Society (HRSS)", 
                    Website = "https://facebook.com/hrsspupmnl",
                    Department = "College of Business Administration (CBA)",  
                    Interests = new List<string> { "Business", "Leadership", "Social Sciences", "Education" } },

            new Organization 
                { 
                    Name = "IIEE-PUP Electrical Engineering Network (EEN)", 
                    Website = "https://www.facebook.com/iieepupeenofficial",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = "Institute of Bachelors in Information Technology Studies (IBITS)", 
                    Website = "https://facebook.com/iBITS.Official",
                    Department = "College of Computer and Information Sciences (CCIS)",  
                    Interests = new List<string> { "Technology", "Innovation", "Science" } },
            
            new Organization 
                { 
                    Name = "Junior Cooperators Association (JCA)", 
                    Website = "https://facebook.com/DCSDJCA",
                    Department = "College of Social Sciences and Development (CSSD)",  
                    Interests = new List<string> { "Leadership", "Business", "Community Building", "Social Issues" } },
            
            new Organization 
                { 
                    Name = "Institution of Mechanical Engineers - Polytechnic University of the Philippines Student Chapter (IMechE-PUPSC)", 
                    Website = "https://facebook.com/IMechEPUPSC", 
                    Interests = new List<string> { "Engineering" } },
            
            new Organization 
                { 
                    Name = "Junior Financial Executives - Polytechnic University of the Philippines (JFINEX-PUP)", 
                    Website = "https://facebook.com/JFINEX.ORG.PUP",
                    Department = "College of Accountancy and Finance (CAF)",  
                    Interests = new List<string> { "Business", "Education", "Community Building", "Leadership" } },
            
            new Organization 
                { 
                    Name = "Junior Marketing Executives (JME)", 
                    Website = "https://facebook.com/PUPJME",
                    Department = "College of Business Administration (CBA)",  
                    Interests = new List<string> { "Business" } },
            
            new Organization 
                { 
                    Name = "Junior Philippine Institute of Environmental Planners - PUP (JPIEP-PUP)", 
                    Website = "https://facebook.com/JPIEPPUP",
                    Department = "College of Architecture, Design and the Built Environment (CADBE)",  
                    Interests = new List<string> { "Leadership", "Nature" } },

            new Organization 
                { 
                    Name = "Kabataan para sa Tribung Pilipino - Polytechnic University of the Philippines (KATRIBU-PUP)", 
                    Website = "https://facebook.com/KATRIBUPUP",
                    Interests = new List<string> { "Culture", "Nature", "Community Building" } },

            new Organization 
                { 
                    Name = "Kabataang Mamamahayag sa Filipinolohiya (KMF)", 
                    Website = "https://facebook.com/KMFilipinolohiya",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Writing", "Design", "Arts & Crafts" } },
            
            new Organization 
                { 
                    Name = "Kalasag Christian Fellowship (KCF)", 
                    Website = "https://facebook.com/KCF.IVCF.PUPManila", 
                    Interests = new List<string> { "Culture", "Community Building", "Volunteering", "Religion" } },
            
            new Organization 
                { 
                    Name = "Literature, Arts, and Culture Society (LACS)", 
                    Website = "https://facebook.com/puplacs",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Education", "Culture" } },

            new Organization 
                { 
                    Name = "Mathematics: Road to Excellence (MATH:RIIX)", 
                    Website = "https://facebook.com/mathriix",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "Move to the Groove (M2TG)", 
                    Website = "https://facebook.com/OfficialM2TG", 
                    Interests = new List<string> { "Music", "Arts & Crafts", "Design", "Dance" } },
            
            new Organization 
                { 
                    Name = "MULAT Documentary Guild (MDG)", 
                    Website = "https://facebook.com/mulatdocumentaryguild", 
                    Interests = new List<string> { "Writing", "Design", "Arts & Crafts" } },
            
            new Organization 
                { 
                    Name = "National Network of Agrarian Reform Advocates Youth - PUP", 
                    Website = "https://facebook.com/NNARAYouth", 
                    Interests = new List<string> { "Volunteering", "Leadership", "Community Building", "Social Issues" } },
            
            new Organization 
                { 
                    Name = "Organization of Junior Physical Educators (OJPE)", 
                    Website = "https://facebook.com/PUPCHKOJPE",
                    Department = "College of Human Kinetics (CHK)",  
                    Interests = new List<string> { "Sports", "Health & Wellness" } },

            new Organization 
                { 
                    Name = "Pambansang Samahan ng Inhenyero Mekanikal - Polytechnic University of the Philippines Student Unit (PSIM-PUPSU)", 
                    Website = "https://facebook.com/psim.pupsu",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = "Peacemakers Movement (PM)", 
                    Website = "https://facebook.com/PeacemakersMovementNewSeason",
                    Interests = new List<string> { "Leadership", "Community Building", "Culture", "Religion" } },
            
            new Organization 
                { 
                    Name = "Philippine Association of Food Technologists, Inc. - Theta Chapter (PAFT Theta)", 
                    Website = "https://facebook.com/pafttheta",
                    Department = "College of Science (CS)",  
                    Interests = new List<string> { "Medicine" } },

            new Organization 
                { 
                    Name = "Philippine Institute of Civil Engineers - Polytechnic University of the Philippines Student Chapter Charter No. 30 (PICE-PUPSC)", 
                    Website = "https://facebook.com/picepupsc30",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = "Philippine Institute of Industrial Engineers - Polytechnic University of the Philippines Student Chapter (PIIE- PUPSC)", 
                    Website = "https://facebook.com/piiepupsc",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = "Polytechnic University of the Philippines - Electronics Engineering Students' Society (PUP-ECESS)", 
                    Website = "https://facebook.com/pup.ecess1979",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Aggregates (PUP Aggregates)", 
                    Website = "https://facebook.com/@pupaggregates/",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },
            
            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Chemical Society (PUP CHEMSOC)", 
                    Website = "https://facebook.com/pupchemsoc",
                    Department = "College of Science (CS)",  
                    Interests = new List<string> { "Science", "Education" } },
            
            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Federation of Junior Philippine Institute of Accountants (PUPFJPIA)", 
                    Website = "https://facebook.com/pupfedjpia", 
                    Interests = new List<string> { "Education", "Leadership" } },

            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Junior Philippine Institute of Accountants Manila (PUP JPIA Manila)", 
                    Website = "https://facebook.com/PUPJPIAManila",
                    Department = "College of Accountancy and Finance (CAF)",  
                    Interests = new List<string> { "Education", "Leadership" } },

            new Organization 
                { 
                    Name = "Polytechnic University of the Philippines Lawôd (PUP Lawôd)", 
                    Website = "https://facebook.com/puplawod",
                    Interests = new List<string> { "Education", "Culture" } },
            
            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Mathematics Club (PUP Math Club)", 
                    Website = "https://www.facebook.com/PUPMathClub",
                    Department = "College of Science (CS)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Physics Society (PUP PhySoc)", 
                    Website = "https://facebook.com/pupphysoc",
                    Department = "College of Science (CS)",  
                    Interests = new List<string> { "Education" } },
            
            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Psychology Students Association (PUPPSA)", 
                    Website = "https://facebook.com/puppsa1982",
                    Department = "College of Social Sciences and Development (CSSD)",  
                    Interests = new List<string> { "Medicine" } },

            new Organization 
                { 
                    Name = "Polytechnic University of the Philippines Railway Engineering Students' Society (PUP RailSS)", 
                    Website = "https://facebook.com/puprailss",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines Seeds of the Nations (PUPSONS)", 
                    Website = "https://facebook.com/pup.seedsofthenations", 
                    Interests = new List<string> { "Leadership", "Community Building", "Volunteering" } },

            new Organization 
                { 
                    Name = " Polytechnic University of the Philippines-Association of DOST Scholars (PUP-ADS)", 
                    Website = "https://facebook.com/PUPADSOfficial", 
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "PUP - Junior Philippine Association of Secretaries and Administrative Professionals (PUP-JPASAP)", 
                    Website = "https://facebook.com/pupjpasap",
                    Department = "Engineering",  
                    Interests = new List<string> { "Leadership" } },

            new Organization 
                { 
                    Name = "PUP Association of Students for Computer Intelligence Integration (PUP ASCII)", 
                    Website = "https://facebook.com/PUPASCII",
                    Department = "College of Computer and Information Sciences (CCIS)",  
                    Interests = new List<string> { "Science", "Technology", "Innovation", "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Bagong Himig Serenata (PUP BHS)", 
                    Website = "https://facebook.com/pupbhs", 
                    Interests = new List<string> { "Music" } },
            
            new Organization 
                { 
                    Name = "PUP Bahaghari (BAHAGHARI-PUP)", 
                    Website = "https://facebook.com/bahagharipup",  
                    Interests = new List<string> { "Culture", "Volunteering", "Community Building", "Humanities" } },
            
            new Organization 
                { 
                    Name = "PUP Balikhaan (PUP BLKN)", 
                    Website = "https://facebook.com/pupbalikhaan", 
                    Interests = new List<string> { "Volunteering", "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Bible Readers Society International (PUP BRead SOCIETY)", 
                    Website = "https://www.facebook.com/ThePUPBRead", 
                    Interests = new List<string> { "Culture", "Volunteering", "Community Building", "Religion" } },
            
            new Organization 
                { 
                    Name = "PUP BiblioFlix (BiblioFlix)", 
                    Website = "https://www.facebook.com/PUPBiblioFlix", 
                    Interests = new List<string> { "Culture", "Volunteering", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP BroadCircle", 
                    Website = "https://facebook.com/pupbroadcircle",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Arts & Crafts", "Media", "Culture", "Social Issues", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Buklod Sining", 
                    Website = "https://facebook.com/pupbuklodsining",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Design", "Arts & Crafts" } },

            new Organization 
                { 
                    Name = "PUP Bukluran sa Sikolohiyang Pilipino", 
                    Website = "https://www.facebook.com/BSPUmalohokan", 
                    Interests = new List<string> { "Social Sciences", "Culture", "Humanities", "Research" } },

            new Organization 
                { 
                    Name = "PUP CADBE Research and Innovation Club", 
                    Website = "https://www.facebook.com/PUP.CADBEResearchInnovationClub",
                    Department = "College of Architecture, Design and the Built Environment (CADBE)",  
                    Interests = new List<string> { "Research", "Education" } },

            new Organization 
                { 
                    Name = "PUP Circle of Research Enthusiasts (PUP CORE)", 
                    Website = "https://www.facebook.com/COREPUP",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Research", "Education" } },

            new Organization 
                { 
                    Name = "PUP COC Ensemble (PUPCOCEnsemble)", 
                    Website = "https://facebook.com/@PUPCOCEnsemble/",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Music", "Writing", "Arts & Crafts" } },

            new Organization 
                { 
                    Name = "PUP College of Engineering Honors' Society (PUP-CEHS)", 
                    Website = "https://www.facebook.com/PUPCEHS1993",
                    Department = "College of Engineering (CE)",  
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = "PUP Communication Society (PUPCOMMSOC)", 
                    Website = "https://facebook.com/pupcommsoc",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "PUP DULAANG SUHAY-FIL (DSF)", 
                    Website = "https://facebook.com/dulaangsuhayfil",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Writing", "Arts & Crafts" } },

            new Organization 
                { 
                    Name = "PUP Economic Research Society (PUP ECONRES)", 
                    Website = "https://www.facebook.com/PUPECONRES1987",
                    Department = "College of Social Sciences and Development (CSSD)",  
                    Interests = new List<string> { "Research", "Education" } },

            new Organization 
                { 
                    Name = "PUP Epistemic League of Interactive future Teachers of English (PUP ELITE)", 
                    Website = "https://www.facebook.com/pupcoed.elite",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "PUP for Jesus Movement (PUPJM)", 
                    Website = "https://facebook.com/PUPforJesusMovement", 
                    Interests = new List<string> { "Culture", "Volunteering", "Community Building", "Religion" } },

            new Organization 
                { 
                    Name = "PUP Harana String Co. (HARANA PUP)", 
                    Website = "https://www.facebook.com/puphsc", 
                    Interests = new List<string> { "Music" } },

            new Organization 
                { 
                    Name = "PUP House of Parliamentarians (PUP-HOP)", 
                    Website = "https://facebook.com/pup.houseofparl", 
                    Interests = new List<string> { "Education", "Research", "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Hygears (PUPHygears)", 
                    Website = "https://facebook.com/PUPHygears", 
                    Interests = new List<string> { "Research", "Education" } },
            
            new Organization 
                { 
                    Name = "PUP Icons (PUPIcons)", 
                    Website = "https://facebook.com/OfficialPUPIcons", 
                    Interests = new List<string> { "Arts & Crafts", "Music", "Design", "Photography", "Dance" } },

            new Organization 
                { 
                    Name = "PUP International Studies Students' Assembly", 
                    Website = "https://www.facebook.com/pupissa.official",
                    Department = "College of Political Science and Public Administration (CPSPA)",  
                    Interests = new List<string> { "Social Sciences", "Humanities", "Culture", "Research", "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Iskusina (PUP-I)", 
                    Website = "https://facebook.com/PUPManilaHMS",
                    Department = "College of Tourism, Hospitality and Transportation Management (CTHTM)",  
                    Interests = new List<string> { "Culture", "Arts & Crafts", "Social Issues", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Journalism Guild", 
                    Website = "https://www.facebook.com/pupjournguild",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Education", "Writing", "Research" } },

            new Organization 
                { 
                    Name = "PUP Junior Philippine Association of Management Accountants (JPAMA)", 
                    Website = "https://www.facebook.com/pupjpama",
                    Department = "College of Accountancy and Finance (CAF)",  
                    Interests = new List<string> { "Business", "Finance", "Leadership", "Research", "Innovation" } },

            new Organization 
                { 
                    Name = "PUP Kabataang Tanggol Wika (PUP KTW)", 
                    Website = "https://www.facebook.com/pupktw",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Culture", "Humanities", "Social Sciences", "Research", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Kasarianlan", 
                    Website = "https://www.facebook.com/PUPKasarianlan", 
                    Interests = new List<string> { "Humanities", "Social Issues" } },

            new Organization 
                { 
                    Name = "PUP League of Advocates for Climate Action and Environmental Sustainability (League of ACES)", 
                    Website = "https://www.facebook.com/pupleagueofaces", 
                    Interests = new List<string> { "Nature", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP Library and Information Science Student Organization (PUP LISSO)", 
                    Website = "https://www.facebook.com/lisso.pup",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education", "Research" } },

            new Organization 
                { 
                    Name = "PUP Peer Facilitators Association (PUPPFA)", 
                    Website = "https://www.facebook.com/puppfa", 
                    Interests = new List<string> { "Education", "Community Building", "Health & Wellness", "Social Sciences" } },

            new Organization 
                { 
                    Name = "PUP Polysound Band (PUP Polysound)", 
                    Website = "https://www.facebook.com/PUPPolysoundOfficial", 
                    Interests = new List<string> { "Music" } },
                
            new Organization 
                { 
                    Name = "PUP Philippine Studies Students Association (PUP PhilSSA)", 
                    Website = "https://www.facebook.com/PUPPhilSSA",
                    Department = "College of Social Sciences and Development (CSSD)",  
                    Interests = new List<string> { "Culture", "Social Sciences", "Research" } },

            new Organization 
                { 
                    Name = "PUP Radicals Judo Team", 
                    Website = "https://www.facebook.com/PUPRadicalsJudoClub", 
                    Interests = new List<string> { "Sports", "Health & Wellness" } },
            
            new Organization 
                { 
                    Name = "PUP Radio Engineering Circle - Manila Section (PUP-REC Manila Section)", 
                    Website = "https://www.facebook.com/PUPREC", 
                    Interests = new List<string> { "Engineering" } },

            new Organization 
                { 
                    Name = "PUP Red Cross Youth Council (PUP RCYC)", 
                    Website = "https://www.facebook.com/pupredcrossyouthcouncil", 
                    Interests = new List<string> { "Medicine" } },

            new Organization 
                { 
                    Name = "PUP School of Debaters (PUP SOD)", 
                    Website = "https://www.facebook.com/PUPSchoolofDebaters", 
                    Interests = new List<string> { "Education", "Research" } },

            new Organization 
                { 
                    Name = "PUP Sintang Pusa (PUP SP)", 
                    Website = "https://www.facebook.com/PUPSintangPusa", 
                    Interests = new List<string> { "Humanities", "Community Building", "Volunteering" } },

            new Organization 
                { 
                    Name = "PUP Society of Biology", 
                    Website = "https://www.facebook.com/pupmanilasbs",
                    Department = "College of Science (CS)",  
                    Interests = new List<string> { "Science" } },

            new Organization 
                { 
                    Name = "PUP Society of Pangasinan Students (PUP SOPAS)", 
                    Website = "https://www.facebook.com/PUPSoPaS", 
                    Interests = new List<string> { "Culture" } },

            new Organization 
                { 
                    Name = "PUP Sociology Society (PUP SocSoc)", 
                    Website = "https://www.facebook.com/PUPSociologySociety",
                    Department = "College of Social Sciences and Development (CSSD)",  
                    Interests = new List<string> { "Social Sciences", "Research", "Social Issues", "Community Building", "Humanities" } },

            new Organization 
                { 
                    Name = "PUP Statistics Students' Clique (PUP StatSClique)", 
                    Website = "https://www.facebook.com/statscliqueker",
                    Department = "College of Science (CS)",  
                    Interests = new List<string> { "Science", "Technology", "Research", "Innovation" } },

            new Organization 
                { 
                    Name = "PUP Sukarela Association of Young Extensionists (PUP SAYE)", 
                    Website = "https://www.facebook.com/pupsaye", 
                    Interests = new List<string> { "Volunteering", "Community Building", "Social Issues", "Education" } },

            new Organization 
                { 
                    Name = "PUP Tanghalang Molave (PUP TM)", 
                    Website = "https://www.facebook.com/profile.php?id=61564278929174",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Music", "Arts & Crafts", "Design", "Dance" } },

            new Organization 
                { 
                    Name = "PUP The Programmers' Guild (PUP-TPG)", 
                    Website = "https://facebook.com/PUPTPG", 
                    Interests = new List<string> { "Technology", "Innovation", "Science" } },

            new Organization 
                { 
                    Name = "PUP The Symposium (PUP TS)", 
                    Website = "https://www.facebook.com/pupthesymposium", 
                    Interests = new List<string> { "Education", "Volunteering", "Community Building", "Innovation" } },

            new Organization 
                { 
                    Name = "PUP Tourism Management Society (PUP TMS)", 
                    Website = "https://www.facebook.com/PUPTMS",
                    Department = "College of Tourism, Hospitality and Transportation Management (CTHTM)",  
                    Interests = new List<string> { "Business", "Education", "Culture", "Community Building" } },

            new Organization 
                { 
                    Name = "PUP TourRise+ (PUP TR+)", 
                    Website = "https://www.facebook.com/PUPTourRise",
                    Department = "College of Tourism, Hospitality and Transportation Management (CTHTM)",  
                    Interests = new List<string> { "Business", "Education", "Culture", "Community Building" } },

            new Organization 
                { 
                    Name = "Pylon Esports", 
                    Website = "https://www.facebook.com/PylonEsports", 
                    Interests = new List<string> { "Gaming" } },

            new Organization 
                { 
                    Name = "Quadro Photography Club", 
                    Website = "https://www.facebook.com/quadrophotographyclub",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Photography", "Arts & Crafts" } },

            new Organization 
                { 
                    Name = "Rotaract Club of Polytechnic University of the Philippines (RAC PUP)", 
                    Website = "https://www.facebook.com/rotaractclubofpup", 
                    Interests = new List<string> { "Volunteering", "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "Sandigan ng Mag-aaral para sa Sambayanan PUP (SAMASA PUP)", 
                    Website = "https://facebook.com/samasapupcthtm", 
                    Interests = new List<string> { "Volunteering", "Leadership", "Community Building", "Social Issues" } },

            new Organization 
                { 
                    Name = "Science Instructors of Education, Nature, Technology, and Innovation Alliance (SCIENTIA)", 
                    Website = "https://www.facebook.com/ScientiaPUP",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education", "Innovation", "Technology" } },

            new Organization 
                { 
                    Name = "Sining na Naglilingkod sa Bayan PUP (SINAGBAYAN PUP)", 
                    Website = "https://www.facebook.com/sinagpup", 
                    Interests = new List<string> { "Arts & Crafts", "Social Issues" } },

            new Organization 
                { 
                    Name = "Societas Philosophiae (SP)", 
                    Website = "https://www.facebook.com/PUPSocietasPhilo",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Leadership", "Education", "Community Building" } },

            new Organization 
                { 
                    Name = "Society of Early Childhood Education (SECEd)", 
                    Website = "https://www.facebook.com/SECEd.Official",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Education" } },

            new Organization 
                { 
                    Name = "Society of Information Technology Educators (SITE)", 
                    Website = "https://www.facebook.com/pupsite",
                    Department = "College of Education (COED)",  
                    Interests = new List<string> { "Technology", "Education" } },

            new Organization 
                { 
                    Name = "Students' Integrated League of Interior Design (SILID)", 
                    Website = "https://www.facebook.com/PUPSILID",
                    Department = "College of Architecture, Design and the Built Environment (CADBE)",  
                    Interests = new List<string> { "Design" } },

            new Organization 
                { 
                    Name = "Tau Gamma Phi/Tau Gamma Sigma (PUP Triskelion)", 
                    Website = "https://www.facebook.com/PUPTriskelion",
                    Interests = new List<string> { "Volunteering", "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "Teatro Komunikado (TK)", 
                    Website = "https://www.facebook.com/teatrokom",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Writing", "Design", "Arts & Crafts", "Photography", "Culture", "Music", "Dance" } },

            new Organization 
                { 
                    Name = "The Jesus Impact - PUP (TJI-PUP)", 
                    Interests = new List<string> { "Culture", "Community Building", "Volunteering", "Religion" } },

            new Organization 
                { 
                    Name = "The PUP Manila Pre-Law Society (PUP PLS)", 
                    Website = "https://www.facebook.com/PUPPrelawSociety", 
                    Interests = new List<string> { "Law", "Social Sciences", "Research" } },

            new Organization 
                { 
                    Name = "Trailblazers Movement (TBM)", 
                    Interests = new List<string> { "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "Tulos Baybay", 
                    Website = "https://www.facebook.com/tulosbaybay",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Culture", "Humanities", "Arts & Crafts" } },

            new Organization 
                { 
                    Name = "UGNAYAN NG TALINO AT KAGALINGAN (UTAK)", 
                    Website = "https://www.facebook.com/UTAK.PUP",
                    Department = "College of Arts and Letters (CAL)",  
                    Interests = new List<string> { "Leadership", "Research", "Innovation" } },

            new Organization 
                { 
                    Name = "United Architects of the Philippines Student Auxiliary - PUP (UPSA-PUP)", 
                    Website = "https://facebook.com/UAPSA.PUP",
                    Department = "College of Architecture, Design and the Built Environment (CADBE)",  
                    Interests = new List<string> { "Design", "Engineering", "Technology" } },

            new Organization 
                { 
                    Name = "Viva Voce COC (VVC)", 
                    Website = "https://www.facebook.com/VivaVoceCOC",
                    Department = "College of Communication (COC)",  
                    Interests = new List<string> { "Culture", "Research", "Education", "Humanities", "Social Issues" } },

            new Organization 
                { 
                    Name = "Wired", 
                    Website = "https://www.facebook.com/pupwired", 
                    Interests = new List<string> { "Technology", "Innovation", "Research" } },

            new Organization 
                { 
                    Name = "Womens' Initiative for Social Development and Freedom (WISDOM)", 
                    Website = "https://www.facebook.com/wisdompup", 
                    Interests = new List<string> { "Social Issues", "Leadership", "Community Building" } },

            new Organization 
                { 
                    Name = "Youth For Animals PUP (YFA PUP)", 
                    Website = "https://www.facebook.com/youthforanimalspup", 
                    Interests = new List<string> { "Nature", "Social Sciences", "Community Building" } },

            new Organization 
                { 
                    Name = "Youth on the Rock (YTR)", 
                    Website = "https://www.facebook.com/ytrorg", 
                    Interests = new List<string> { "Religion", "Community Building", "Social issues" } },

         };

        
        
        var results = organizations
            .Where(org => 
                profile.Department == null ||  // User didn't select a department OR
                string.Equals(org.Department, profile.Department, StringComparison.OrdinalIgnoreCase) || // Department matches (case-insensitive) OR
                string.IsNullOrEmpty(org.Department) // Organization has NO department listed
            )
            .Where(org => 
                profile.Program == null || // User didn't select a program OR
                (org.Programs != null && org.Programs.Any(program => string.Equals(program, profile.Program, StringComparison.OrdinalIgnoreCase))) || // Program matches (case-insensitive) OR
                org.Programs == null || org.Programs.Count == 0 // Organization has NO programs listed
            )
            .Where(org => profile.Interests.Any(interest => org.Interests.Any(orgInterest => string.Equals(orgInterest, interest, StringComparison.OrdinalIgnoreCase)))) // Interests (case-insensitive)
            .ToList();

        // 2. Check if results is null or empty after filtering (important for debugging):
        if (results == null || results.Count == 0)
        {
            // Log this.  It means no organizations matched the criteria.
        }

        return View(results); // This line is absolutely essential!
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

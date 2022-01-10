using Microsoft.AspNetCore.Mvc;

namespace FirstWeekProject.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ProgrammingLanguageController : ControllerBase
    {
        private static List<ProgrammingLanguages> ProgrammingLanguages = new List<ProgrammingLanguages>()
      {
          new ProgrammingLanguages
          {
              id=1,ProgrammingLanguagesNames="CSharp",ProgrammingLanguageDate=2000,ProgrammingLanguageCreater="Microsot"
          },

           new ProgrammingLanguages
          {
              id=2,ProgrammingLanguagesNames="Python",ProgrammingLanguageDate=1990,ProgrammingLanguageCreater="Guido Van Rossom"
          },

            new ProgrammingLanguages
          {
              id=3,ProgrammingLanguagesNames="Kotlin",ProgrammingLanguageDate=2011,ProgrammingLanguageCreater="Jet Brains"
          }
      };

        private readonly ILogger<ProgrammingLanguageController> _logger;

        public ProgrammingLanguageController(ILogger<ProgrammingLanguageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<ProgrammingLanguages> GetProgrammingLanguages()
        {
           var programmingLanguages=ProgrammingLanguages.OrderBy(p=>p.id).ToList();
            return programmingLanguages;
        }

        [HttpGet("{name}")]
        public ProgrammingLanguages GetProgrammingLanguagesByName(string name)
        {
            var programmingLanguage = ProgrammingLanguages.SingleOrDefault(p => p.ProgrammingLanguagesNames == name);
            return programmingLanguage;
        }

        [HttpPost]
        public IActionResult AddProgrammingLanguage([FromBody] ProgrammingLanguages newProgrammingLanguage)
        {
            var programmingLanguage = ProgrammingLanguages.SingleOrDefault(p => p.ProgrammingLanguagesNames == newProgrammingLanguage.ProgrammingLanguagesNames);
            if (programmingLanguage is not null)
            {
                return BadRequest();
            }
            ProgrammingLanguages.Add(newProgrammingLanguage);
            return Ok();
        }

    }
}
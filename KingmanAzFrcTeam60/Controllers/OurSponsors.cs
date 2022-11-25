using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KingmanAzFrcTeam60.Controllers
{
    [Route("OurSponsors")]
    [ApiController]
    public class OurSponsors : ControllerBase
    {
        // GET: api/<Sponsors>
        [HttpGet]
        public string Get()
        {
            var path = Path.GetFullPath("wwwroot");
            var str = System.IO.File.ReadAllText(Path.Combine(path, "Sponsors2.json"));
            
            return str;
        }

        //// GET api/<Sponsors>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}

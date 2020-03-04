using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;

namespace APIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DWCController : ControllerBase
    {
        [HttpGet]
        [Route("GetProgrammer")]
        public IActionResult Get()
        {
            var client = new RestClient("http://www.dominicanwho.codes/data/developers.json");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            List<DWVProgrammers> datosProgramadores = JsonConvert.DeserializeObject<List<DWVProgrammers>>(response.Content);
            return Ok(datosProgramadores);
        }

        [HttpGet]
        [Route("GetProgrammer/{Name}")]
        public IActionResult Get(string Name)
        {
            var client = new RestClient("http://www.dominicanwho.codes/data/developers.json");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            List<DWVProgrammers> datosProgramadores = JsonConvert.DeserializeObject<List<DWVProgrammers>>(response.Content);

            return Ok(datosProgramadores.Where(a => a.Name.Contains(Name)).ToList());
        }
    }


    public class DWVProgrammers
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string[] SkillsList => Skills.Split(',');
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Webpage { get; set; }
        public string Twitter { get; set; }
        public string Stackoverflow { get; set; }
        public string Telegram { get; set; }
        public string YouTube { get; set; }
    }
}
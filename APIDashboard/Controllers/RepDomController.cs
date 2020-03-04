using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepDomController : ControllerBase
    {
        private readonly DBAPIFUELSContext _context;

        public RepDomController(DBAPIFUELSContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetProvincias")]
        public IActionResult Provincias() {

            var provincias = _context.Provincias.ToList();
            return Ok(provincias);
        }
        

        [HttpGet]
        [Route("GetMunicipios/{ProvinciaID}")]
        public IActionResult Municipios(int ProvinciaID)
        {

            var municipios = _context.Municipios.Where(w=>w.ProvinciaId == ProvinciaID).ToList();
            return Ok(municipios);
        }

        [HttpGet]
        [Route("GetSectores/{MunicipioID}")]
        public IActionResult Sectores(int MunicipioID)
        {

            var sectores = _context.Sectores.Where(w => w.MunicipioId == MunicipioID).ToList();
            return Ok(sectores);
        }
    }
}
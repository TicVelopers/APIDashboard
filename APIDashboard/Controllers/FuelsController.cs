using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDashboard.Models;

namespace APIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly DBAPIFUELSContext _context;

        public FuelsController(DBAPIFUELSContext context)
        {
            _context = context;
        }

        // GET: api/Fuels/5
        
        public IActionResult Get(string fuelname="",DateTime date=default,DateTime datefrom = default, DateTime dateto = default)
        {


            var tdCombustibles = _context.TdCombustibles.Where(w => w.Combustible == fuelname).ToList();

            return Ok(tdCombustibles);
        }

        
        //public IActionResult Get(string fuelname, DateTime date)
        //{


        //    var tdCombustibles = _context.TdCombustibles.Where(w => w.Combustible == fuelname && w.FechaSemana == date).ToList();

        //    return Ok(tdCombustibles);
        //}


    }
}

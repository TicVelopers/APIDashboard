using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplementController : BaseController
    {
        public ImplementController(UnitOfWork unitOfWork) :base(unitOfWork) 
        { 
        
        }

        [HttpGet]
        [Route("GetUCombustibles")]
        public IActionResult Provincias()
        {

            var combustibles = _UnitOfWork.Combustibles.Get();
   
            return Ok(combustibles);
        }
    }
}

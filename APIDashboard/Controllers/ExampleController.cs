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
    public class ExampleController : ControllerBase
    {
        private readonly DBAPIFUELSContext db;

        public ExampleController(DBAPIFUELSContext _db)
        {
            db = _db;
        }
        // GET: api/Example
        [HttpGet]
        public List<TdCombustibles> Get()
        {
            var Data = db.TdCombustibles.ToList();
            return Data;
        }

        // GET: api/Example/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Example
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Example/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDashboard.Models;
using APIDashboard.Services;
using APIDashboard.Models.ModelsDTO;

namespace APIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
      
        private readonly DBAPIFUELSContext _context;
        private readonly AutoMap MapClient;
        public FuelsController(DBAPIFUELSContext context, AutoMap _MapClient)
        {
            _context = context;
            MapClient = _MapClient;
        }

        [HttpGet]
        [Route("GetFuels")]
        public IActionResult find(string fuelname = "", DateTime? date = null, DateTime? datefrom  = null, DateTime? dateto = null )
        {
            var tdCombustibles = _context.TdCombustibles.Where(w =>
            (string.IsNullOrEmpty(fuelname) || w.Combustible == fuelname) &&
            (!date.HasValue || w.FechaSemana.Value == date.Value) &&
            (!datefrom.HasValue || w.FechaSemana.Value >= datefrom.Value) &&
            (!dateto.HasValue || w.FechaSemana.Value <= dateto.Value)
            ).ToList();

            var fuelsDTO = MapClient.MapperConvertList<TdCombustibles, FuelsDTO>(tdCombustibles);
            
            return Ok(fuelsDTO);
        }


    }
}

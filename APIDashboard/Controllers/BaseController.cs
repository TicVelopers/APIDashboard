using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Entities.Models;
using APIDashboard.Models;
using APIDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork _UnitOfWork;

        public BaseController(IUnitOfWork unitOfWork) {

            _UnitOfWork = unitOfWork;
        }

    }
}

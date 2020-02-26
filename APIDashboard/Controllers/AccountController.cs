using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly DBAPIFUELSContext db;
        public AccountController(DBAPIFUELSContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int id)
        {
            var UserDetails = db.TdUser.Where(w => w.Id == id).FirstOrDefault();
            return View(UserDetails);
        }

        public IActionResult SignUp()
        {
            ViewBag.Error = "";
            return View();
        }

        [HttpPost("/Account/SignUp")]
        public IActionResult SignUp(TdUser UserData)
        {
            if (ModelState.IsValid)
            {
                try {

                    if (db.TdUser.Where(w=>w.UserName==UserData.UserName).Any()) {

                        //ViewBag.Error = "This User Already Exist, Please Try with another one";
                        //return View();
                        return Json(new { DataResult = new { icon = "error", text = "Este cliente ya existe en la base de datos", title = "Oops!" } });
                    }
                    else {
                        db.TdUser.Add(UserData);
                        db.SaveChanges();
                        //return RedirectToAction("Index", "Home");
                        return Json(new { DataResult = new { icon = "success", text = "Este cliente fue agregado exitosamente", title = "Agregado" }, state = 200 });
                    }

                    
                }
                catch(Exception e) {
                    //ViewBag.Error = e.ToString();
                    //return View();
                    return Json(new { DataResult = new { icon = "error", text = "Algo anduvo mal creando el usuario, favor revisar los datos y tratar nuevamente", title = "Oops!" } });
                }
            }
            else {
                //ViewBag.Error = "Something Went Wrong!!!";
                //return View();
                return Json(new { DataResult = new { icon = "error", text = "Algo anduvo mal creando el usuario, favor revisar los datos y tratar nuevamente", title = "Oops!" } });
            }
            
        }
    }
}
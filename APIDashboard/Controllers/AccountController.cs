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

                        ViewBag.Error = "This User Already Exist, Please Try with another one";
                        return View();
                    }
                    else {
                        db.TdUser.Add(UserData);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }

                    
                }
                catch(Exception e) {
                    ViewBag.Error = e.ToString();
                    return View();
                }
            }
            else {
                ViewBag.Error = "Something Went Wrong!!!";
                return View();
            }
            
        }
    }
}
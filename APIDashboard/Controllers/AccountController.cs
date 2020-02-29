using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APIDashboard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
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


        [HttpPost]
        public async Task<IActionResult> Login(TdUser UserLoginForm)
        {
            if (ModelState.IsValid)
            {

                if (db.TdUser.Where(a => a.UserName == UserLoginForm.UserName && a.UserPass == UserLoginForm.UserPass && a.Status == "A").ToList().Count() > 0)
                {
                    var DataUser = db.TdUser.Where(w => w.UserName == UserLoginForm.UserName).FirstOrDefault();
                    // Initialization.    
                    var claims = new List<Claim>();
                    try
                    {
                        // Setting    
                        claims.Add(new Claim(ClaimTypes.Name, UserLoginForm.UserName));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties { IsPersistent = false };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        return Json(new { state = 200 });

                    }
                    catch (Exception ex)
                    {

                        return Json(new { DataResult = new { icon = "error", text = "Something went wrong trying to login please try again!", title = "Oops!" } });
                    }

                }
                else
                {
                    return Json(new { DataResult = new { icon = "error", text = "Username or password are incorrects, please try again!", title = "Oops!" } });

                }


            }
            else {
                return Json(new { DataResult = new { icon = "error", text = "Maybe is something bad in your User data", title = "Oops!" } });
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {

            try
            {
                await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                  
                throw ex;
            }

        }

    }
}
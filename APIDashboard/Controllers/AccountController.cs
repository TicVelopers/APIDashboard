using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APIDashboard.Models;
using APIDashboard.Models.ModelsDTO;
using APIDashboard.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly DBAPIFUELSContext db;
        private readonly AutoMap MapClient;
        private readonly APIKeyGenerator genKey;
        public AccountController(DBAPIFUELSContext _db, AutoMap _MapClient, APIKeyGenerator _genKey)
        {
            db = _db;
            MapClient = _MapClient;
            genKey = _genKey;
        }
        public IActionResult Index(int id)
        {
            var UserDetails = db.TdUser.Where(w => w.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userDTO = MapClient.MapperConvert<TdUser, UserDTO>(UserDetails);
            return View(userDTO);
        }

        public IActionResult SignUp()
        {
            ViewBag.Error = "";
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(TdUser UserData)
        {
            if (ModelState.IsValid)
            {
                try {

                    if (db.TdUser.Where(w=>w.UserName==UserData.UserName).Any()) {

                       
                        return Json(new { DataResult = new { icon = "error", text = "This User Already exist", title = "Oops!" } });
                    }
                    else {
                        UserData.Status = "A";
                        var GeneratedKey = genKey.CreateApiKey();
                        UserData.ApiKey = GeneratedKey;
                        db.TdUser.Add(UserData);
                        db.SaveChanges();
                        db.UserInRole.Add(new UserInRole() { RoleName = "User", UserName = UserData.UserName});
                        db.SaveChanges();
                        return Json(new { DataResult = new { icon = "success", text = "This user was successfully created", title = "Agregado" }, state = 200 });
                    }

                    
                }
                catch(Exception e) {
                    return Json(new { DataResult = new { icon = "error", text = "Somenthing went wrong went trying to create this user, please try again", title = "Oops!" } });
                }
            }
            else {
                return Json(new { DataResult = new { icon = "error", text = "Somenthing went wrong went trying to create this user, maybe some data is wrong", title = "Oops!" } });
            }
            
        }




        [HttpGet]
        public IActionResult Login(string ReturnUrl = "") {

            return Redirect("~/register.html");
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

        //[HttpGet]
        public async Task<IActionResult> LogOff()
        {

            try
            {
                await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("~/register.html");
            }
            catch (Exception ex)
            {
                  
                throw ex;
            }

        }

        [HttpGet]
        public IActionResult GenerateApiKey() {

            try {
                var key = genKey.CreateApiKey();
                var userProfile = db.TdUser.Where(w => w.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
                userProfile.ApiKey = key;
                db.Entry(userProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return StatusCode(200,userProfile.ApiKey);
            }
            catch (Exception ex) {
                return StatusCode(400,ex);
            }
            
        }

    }
}
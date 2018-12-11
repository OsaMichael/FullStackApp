using FullStackApp.Core.Business;
using FullStackApp.Core.Interface;
using FullStackApp.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FullStackApp.Web.Controllers
{
    public class AccountController : Controller
    {

        private IUserManager _userMgr;

        IAuthenticationManager _auth => HttpContext.GetOwinContext().Authentication;
        // private IAuthenticationManager AuthenticationManager() => HttpContext.GetOwinContext().Authentication;

        //IAuthenticationManager _auth => HttpContext.GetOwinContext().Authentication;

        public AccountController(IUserManager userMgr)
        {
            _userMgr = userMgr;
        }


        //  GET: Account
        public ActionResult Login()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Error = TempData["message"];
                ModelState.AddModelError(string.Empty, ViewBag.Error.ToString());
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                //verify user
                var result = _userMgr.ValidateUser(model.Email, model.Password);
                //AntiXssEncoder.HtmlEncode(model.UserName, true);
                if (result.Succeeded == true && result.Result == true)
                {
                    //get claims
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Email),
                        //new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Name, model.Email),
                    };

                    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    //sign in use
                    _auth.SignIn(identity);
                    ViewBag.message = "Successful login";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    ViewBag.error = "Sorry you cannot login";
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Sorry you cannot login");
                ViewBag.error = "Sorry you cannot login";
                return View(model);
            }


        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //using (DataContext db = new DataContext())
                //{
                var result = _userMgr.CreateUser(model);

                if (result.Succeeded)
                {
                    TempData["message"] = " Employee{ model.Email} was successfully added";
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError(string.Empty, result.Message);
                ViewBag.Error = "Error occured : {result.Message}";
                return View(model);
            }
            return View(model);
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterRole()
        {
            ViewBag.Name = new SelectList(_userMgr.GetRoles().Result, "RoleId", "RoleName");
            ViewBag.UserName = new SelectList(_userMgr.GetUsers().Result, "UserId", "Email");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //since i m passing only two values of the usres// if i have more than two values i can pass it using model or creating a model for it
        public ActionResult RegisterRole(int userId, int roleId)
        {
       
            ViewBag.Name = new SelectList(_userMgr.GetRoles().Result, "RoleId", "RoleName");
            ViewBag.UserName = new SelectList(_userMgr.GetUsers().Result, "UserId", "Email");

           _userMgr.AssignRole(userId,roleId);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOff()
        {
            _auth.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Home", new { Area = "" });
        }



        //    var isValid = true;
        //    if (isValid)
        //    {
        //        SignIn(model);
        //    }


        //    if (!string.IsNullOrEmpty(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(model);
        //}


        //private void SignIn(LoginModel model)
        //{
        //    var claims = new Claim[]
        //        {

        //                new Claim(ClaimTypes.NameIdentifier, "1"),
        //                new Claim(ClaimTypes.Email, model.Email),
        //                new Claim(ClaimTypes.Role, "Admin"),
        //                new Claim(ClaimTypes.Name, model.Email),
        //    };
        //    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        //    _auth.SignIn(identity);

        //    //return View(model);

        //}



        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(LoginModel model, string returnUrl)
        //{
        //    var validateAndSignIn = from user in ValidateUser(model)
        //                            from signIn in SignIn(user, model.RememberMe)
        //                            select user;

        //    //TODO: Peform Validation
        //    var isValid = validateAndSignIn.Succeeded;
        //    //Sign User In
        //    if (isValid)
        //    {
        //        //Redirect to Home
        //        return RedirectToAction("index", "home");
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}

        //private Operation<User> ValidateUser(LoginModel model)
        //{
        //    return Operation.Create(() =>
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = _user.FindByEmail(model.Email);
        //            if (user == null) throw new Exception("Invalid Username or Password");
        //            return user;
        //        }
        //        else
        //        {
        //            var error = ModelState.Values.SelectMany(v => v.Errors)
        //                                         .Select(e => e.ErrorMessage)
        //                                         .Aggregate((ag, e) => ag + ", " + e);
        //            throw new Exception(error);
        //        }
        //    });
        //}

        //private Operation<ClaimsIdentity> SignIn(User model, bool rememberMe)
        //{
        //    return Operation.Create(() =>
        //    {
        //        var identity = _user.CreateIdentityAsync(model, DefaultAuthenticationTypes.ApplicationCookie).Result;

        //        //Optionally Add Additional Claims

        //        Authentication.SignIn(new AuthenticationProperties { IsPersistent = rememberMe }, identity);

        //        return identity;
        //    });
        //}

        //[HttpPost]
        //public ActionResult ResetPassword(object model)
        //{
        //    var user = _user.FindByName("admin@gmail.com");
        //    var newPassword = "12345";
        //    if (user != null)
        //    {
        //        var token = _user.GeneratePasswordResetToken(user.UserId);
        //        //Send Token to User
        //        _user.ResetPassword(user.UserId, token, newPassword);
        //    }
        //    return RedirectToAction("login");

        //}
        //[HttpPost]
        //public ActionResult LogOff()
        //{
        //    //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    //Session.Clear();
        //    //Session.Abandon();
        //    //Session.RemoveAll();
        //    //FormsAuthentication.SignOut();
        //    //return RedirectToAction("Index", "Home");


        //    Session.Clear();
        //    Session.Abandon();
        //    Session.RemoveAll();
        //    FormsAuthentication.SignOut();
        //    Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("login");
        //}

        //public ActionResult NotAuthorized()
        //{
        //    return RedirectToAction("login");
        //}

        //public ActionResult SignUp()
        //{
        //    return View();
        //}
    }
}
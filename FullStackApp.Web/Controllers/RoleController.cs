using FullStackApp.Core.Business;
using FullStackApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullStackApp.Web.Controllers
{
 
        public class RoleController : Controller
        {
            private IUserManager _userMgr;
            public RoleController(IUserManager userMgr)
            {
                _userMgr = userMgr;
            }
            // GET: Role
            public ActionResult Index()
            {
                var result = _userMgr.GetRoles();
                return View(result);
            }
            public ActionResult CreateRole()
            {
                var roles = new RoleModel();
                return View(roles);
            }
            [HttpPost]
            public ActionResult CreateRole(RoleModel model)
            {
                var roles = _userMgr.CreateRole(model);
                if (roles.Succeeded)
                {
                    TempData["message"] = $" Employee{ model.RoleId} was successfully added";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, roles.Message);
                ViewBag.Error = $"Error occured : {roles.Message}";
                return View(model);

            }
        }
    }

using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullStackApp.Web.Controllers
{
    public class HomeController : Controller
    {
        //[AuthorizeUser("Home-Page")]
        [Authorize]

      // GET: Home
            public ActionResult Index()
            {
                {

                    string email = User.Identity.GetUserName();

                    return View();
                }
            }
            //[Authorize(Roles = "Admin")]
            public ActionResult Admin()
            {
                return View();
            }

        }
    }

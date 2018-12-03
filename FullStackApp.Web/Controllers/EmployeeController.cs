using FullStackApp.Core.Business;
using FullStackApp.Core.Interface;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullStackApp.Web.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeManager _empMgr;
        public EmployeeController(IEmployeeManager empMgr)
        {
            _empMgr = empMgr;
        }
        // GET: Employee
        public ActionResult Index()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Sucess = (string)TempData["message"];
            }
            var models = _empMgr.GetEmployees();
            if (models.Succeeded == true)
            {
                return View(models.Unwrap());
            }
            else
            {
                ModelState.AddModelError(string.Empty, "an error occure");
                return View();
            }

        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel model)
        {
            model.CreatedBy = User.Identity.GetUserName();
            var result = _empMgr.CreateEmployee(model);
            if (result.Succeeded == true)
            {
                TempData["message"] = $" Employee{ model.EmployeeId} was successfully added";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, result.Message);
            ViewBag.Error = $"Error occured : {result.Message}";
            return View(model);
        }
        [HttpGet]
        public ActionResult EditEmployee(int id = 0)
        {
            var result = _empMgr.GetEmployeeById(id);
            if (result.Succeeded == true)
            {
                return View(result.Message);
            }
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedBy = User.Identity.GetUserName();
                var result = _empMgr.UpdateEmployee(model);
                if (result.Succeeded == true)
                {
                    TempData["message"] = $"Employee{model.EmployeeId} was successfully added";
                    ModelState.AddModelError(string.Empty, "Update was successful ");
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, result.Message);
                ViewBag.Error = $"an error ocure : {result.Message}";
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
    }
}
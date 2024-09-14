using BusinessLogic;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationForm.Controllers
{
    public class HomeController : Controller
    {

        UserService userService = new UserService();

        public ActionResult Index()
        {
            var users = userService.GetAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            ViewBag.States = new SelectList(userService.GetStates(), "Id", "StateName");
            return PartialView("_UserForm", new User());
        }

        public ActionResult Edit(int id)
        {
            var user = userService.GetUserById(id);
            ViewBag.States = new SelectList(userService.GetStates(), "Id", "StateName");
            ViewBag.Cities = new SelectList(userService.GetCitiesByState(user.StateId), "Id", "CityName");
            return PartialView("_UserForm", user);
        }

        [HttpPost]
        public JsonResult Save(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id == 0)
                {
                    userService.AddUser(user);
                }
                else
                {
                    userService.UpdateUser(user);
                }
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            userService.DeleteUser(id);
            return Json(new { success = true });
        }

        [HttpGet]
        public JsonResult GetCitiesByState(int stateId)
        {
            var cities = userService.GetCitiesByState(stateId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}
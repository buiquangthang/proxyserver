using ProxyMVCv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProxyMVCv1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {

            if (ModelState.IsValid)
            {

                var dataFile = Server.MapPath("~/App_Data/User.txt");

                var result = "";
                Array userCount = null;
                if (System.IO.File.Exists(dataFile))
                {
                    userCount = System.IO.File.ReadAllLines(dataFile);
                    if (userCount == null)
                    {
                        // Empty file.
                        result = "The file is empty.";
                    }
                }
                else
                {
                    // File does not exist.
                    result = "The file does not exist.";
                }
                if (result == "")
                {

                    foreach (string dataLine in userCount)
                    {
                        var dataItem = dataLine.Split(',');

                        if (dataItem[1] == user.Username && dataItem[2] == user.Password)
                        {
                            Session["username"] = "username";
                            return RedirectToAction("Index","Proxy");
                        }
                        else
                        {
                            ViewBag.result = "Username or password is fail";
                            return View();
                        }
                    }
                }
                return View();
            }

            return View();

        }
    }
}
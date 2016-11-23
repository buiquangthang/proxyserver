using ProxyMVCv1.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProxyMVCv1.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
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
            var listUser = new List<UserModel>();
            if (result == "")
            {
                foreach (string dataLine in userCount)
                {
                    var dataItem = dataLine.Split(',');
                    listUser.Add(new UserModel { Id = int.Parse(dataItem[0]), Username = dataItem[1].ToString(), Password = dataItem[2].ToString() });
                }
            }

            return View(listUser);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
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

                var userId = 0;
                if (result == "")
                {
                    foreach (string dataLine in userCount)
                    {
                        var dataItem = dataLine.Split(',');

                        if (dataItem[1] == user.Username)
                        {
                            result = "Username Exists";
                            ViewBag.result = result;
                            return View();
                        }
                        userId = userCount.Length;
                    }
                }

                var userData = userId++ + "," + user.Username + "," + user.Password.ToString() + Environment.NewLine;
                System.IO.File.AppendAllText(@dataFile, userData);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
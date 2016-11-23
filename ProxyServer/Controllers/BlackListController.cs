using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProxyServer.Models;

namespace ProxyServer.Controllers
{
    public class BlackListController : Controller
    {
        //
        // GET: /BlackList/

        public ActionResult Index()
        {
            var dataFile = Server.MapPath("~/App_Data/blacklist.txt");

            //System.IO.File.WriteAllText(@dataFile, userData);
            var result = "";
            Array SiteCount = null;
            if (System.IO.File.Exists(dataFile))
            {
                SiteCount = System.IO.File.ReadAllLines(dataFile);
                if (SiteCount == null)
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
                ViewBag.SiteCount = SiteCount;
            }

            return View();
        }

        //
        // GET: /BlackList/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BlackList/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BlackList/Create

        [HttpPost]
        public ActionResult Create(BlackListModel model)
        {
            if (ModelState.IsValid)
            {

                var dataFile = Server.MapPath("~/App_Data/blacklist.txt");
                var result = "";
                Array SiteCount = null;
                if (System.IO.File.Exists(dataFile))
                {
                    SiteCount = System.IO.File.ReadAllLines(dataFile);
                    if (SiteCount == null)
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

                var SiteId = 0;
                if (result == "")
                {

                    foreach (string dataLine in SiteCount)
                    {
                        var dataItem = dataLine.Split(',');

                        if (dataItem[1] == model.site)
                        {
                            result = "Loi dinh menh";
                            ViewBag.result = result;
                            return View();
                        }
                        SiteId = SiteCount.Length;
                    }
                }


                var SiteData = SiteId++ + "," + model.site + Environment.NewLine;
                System.IO.File.AppendAllText(@dataFile, SiteData);
                return RedirectToAction("Index", "Proxy");


            }
            return View();
        }

        //
        // GET: /BlackList/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BlackList/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BlackList/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BlackList/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

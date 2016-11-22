using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProxyServer.Models;

namespace ProxyServer.Controllers
{
    public class ProxyController : Controller
    {
        public ProxyModel proxymod = new ProxyModel();
        //
        // GET: /Proxy/
        public ActionResult Index()
        {
            ViewData["ListProxy"] = proxymod.ListProxy();
            return View();
        }

        //
        // GET: /Proxy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Proxy/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Proxy/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var classtype = Request["type"];
                var host = Request["host"];
                var port = Request["port"];
                proxymod.StartProxy(classtype,host,port);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Proxy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Proxy/Edit/5
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
        // GET: /Proxy/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                proxymod.DeleteProxy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

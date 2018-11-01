using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Notfound(string aspxerrorpath)
        {
            ViewBag.hata = aspxerrorpath;
            return View();
        }
    }
}
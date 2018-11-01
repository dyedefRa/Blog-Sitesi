using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.UI.Models;

namespace Blog.UI.App_Classes
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        //ActionMetod çalıştırıldıktan sonra devreye girer.
        // Home/Index e verdik ..
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var sessionControl = (Kullanici)filterContext.HttpContext.Session["aktifKullanici"];
            if (sessionControl == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });

            }
        }
    }
}
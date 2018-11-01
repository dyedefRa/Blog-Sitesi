using Blog.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {
        DufyContext ctx = new DufyContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici temp)
        {
            try
            {
                var varmi = ctx.Kullanici.FirstOrDefault(x => x.KullaniciAdi == temp.KullaniciAdi && x.Parola == temp.Parola);
                if (varmi != null)
                {
                    Session["aktifKullanici"] = varmi;
                    return RedirectToAction("Index","Kullanici");
                }
                else
                {
                    TempData["loginHatasi"] = "Kullanıcı adı ve parola uyuşmuyor";
                    return View();
                }

            }
            catch (Exception)
            {
                TempData["loginHatasi2"] = "Sistemde hata oluştu";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["aktifKullanici"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        public ActionResult Create(Kullanici kullanici)
        {
            try
            {
                if (ctx.Kullanici.Any(x => x.KullaniciAdi == kullanici.KullaniciAdi))
                {
                    return View();
                }
                //if(kullanici.Parola==null|| kullanici.KullaniciAdi==null||kullanici.Ad==null)
                //{
                //    return View();
                //}
                ctx.Kullanici.Add(kullanici);
                ctx.SaveChanges();

                var idliKullanici = ctx.Kullanici.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi);

                Session["aktifKullanici"] = idliKullanici;

                return RedirectToAction("Index","Kullanici");
            }
            catch
            {

                return View();
            }
        }
    }
}
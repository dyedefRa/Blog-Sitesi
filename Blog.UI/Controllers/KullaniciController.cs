using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.UI.Models;
using Blog.UI.App_Classes;
using System.Data.Entity.Migrations;
 
namespace Blog.UI.Controllers
{
   [LoginFilter]
    public class KullaniciController : Controller
    {
        DufyContext ctx = new DufyContext();
        // GET: Kullanici
        public ActionResult Index()
        {
            var aktifKullanici = (Kullanici)Session["aktifKullanici"];

            //var kullanici = ctx.Kullanici.FirstOrDefault(x => x.KullaniciAdi == aktifKullanici.KullaniciAdi);
            //ViewBag.Kul = kullanici.KullaniciAdi;
            return View(aktifKullanici);
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int id)
        {
            var kullanici = ctx.Kullanici.FirstOrDefault(x => x.Id == id);
            if (kullanici != null)
            {
                return View(kullanici);
            }

            return HttpNotFound();
        }

        #region EDIT

        // GET: Kullanici/Edit/5
        public ActionResult Edit(int id)
        {

          

            var aktifKullanici = (Kullanici)Session["aktifKullanici"];
            //Şuanki kullanıcı editlemek istemıyorsa yada admin degilse

            if (AdminAyrimi.EditeIzinVarmi(aktifKullanici,id))
            {
                ViewBag.yetkiler = new SelectList(ctx.Yetki, "Id", "Adi");
                var kullanici = ctx.Kullanici.FirstOrDefault(x => x.Id == id);
                return View(kullanici);
            }
            return HttpNotFound("Bu sayfaya erisim hakkiniz bulunmamaktadir.");


            //BURAYI AdminAyrimi Sınıfında hallettık
            //if (aktifKullanici.Id == id || aktifKullanici.YetkiID > 2)
            //{
            //    ViewBag.yetkiler = new SelectList(ctx.Yetki, "Id", "Adi");
            //    var kullanici = ctx.Kullanici.FirstOrDefault(x => x.Id == id);
            //    return View(kullanici);
            //}
            //return HttpNotFound("Bu sayfaya erisim hakkiniz bulunmamaktadir.");

        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Kullanici kullanici, ParolaOlayi parolalar)
        {
            try
            {
                //Parola degğiştirmeyecekse

                if (parolalar.eskiParola != kullanici.Parola)
                {
                    TempData["editHatasi"] = "Önceki parolayı doğrulamanız gerekmektedir..";
                    return RedirectToAction("Edit", id);
                }
                if (parolalar.yeniParola2 != null && parolalar.yeniParola1 != null && parolalar.yeniParola1 == parolalar.yeniParola2)
                {
                    kullanici.Parola = parolalar.yeniParola1;
                }
                ctx.Kullanici.AddOrUpdate(kullanici);
                ctx.SaveChanges();
                TempData["editOlayi"] = "İşlem başarıyla tamamlandı..";
                return RedirectToAction("Edit", id);
            }
            catch
            {
                TempData["editHatasi2"] = "Bir sorun oluştu.Lütfen daha sonra tekrar deneyiniz..";
                return RedirectToAction("Edit", id);
            }
        }


        #endregion

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int id)
        {
            if (AdminAyrimi.DeleteIzinVarmi((Kullanici)Session["aktifKullanici"], id))
            {
                var kullanici = ctx.Kullanici.FirstOrDefault(x => x.Id == id);
                return View(kullanici);

            }
            return HttpNotFound("Buraya erisim izniniz bulunmamaktadir.");
        }
        //BURASI EKSIK@@@@@@@@@@
        // POST: Kullanici/Delete/5
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

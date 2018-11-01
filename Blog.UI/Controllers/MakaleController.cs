using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.UI.App_Classes;
using Blog.UI.Models;

namespace Blog.UI.Controllers
{
    [LoginFilter]
    public class MakaleController : Controller
    {
        DufyContext ctx = new DufyContext();

        public void YorumSilici(int id)
        {
            var yorum = ctx.Yorum.FirstOrDefault(x => x.Id == id);
            ctx.Yorum.Remove(yorum);
            ctx.SaveChanges();

        }

        public JsonResult AjaxYorum(int yorumYapanID, int makaleID, string yorum)
        {
            try
            {
                if (string.IsNullOrEmpty(yorum))
                {
                    return Json(new RESULTJSON { Durum = false, Mesaj = "Boş yorum yapılamaz." });
                }
                var yapilanYorum = new Yorum();
                yapilanYorum.Icerik = yorum;
                yapilanYorum.KullaniciID = yorumYapanID;
                yapilanYorum.MakaleID = makaleID;
                ctx.Yorum.Add(yapilanYorum);
                ctx.SaveChanges();
                return Json(new RESULTJSON { Durum = true, Mesaj = "Yorum yapıldı." });
            }
            catch
            {

                return Json(new RESULTJSON { Durum = false, Mesaj = "Hata oluştu." });
            }


        }

        public JsonResult AjaxYorumSil(int id)
        {

            try
            {
                YorumSilici(id);
                return Json(new RESULTJSON { Durum = true, Mesaj = "Yorum başarıyla silindi." });
            }
            catch
            {

                return Json(new RESULTJSON { Durum = false, Mesaj = "Bir hata oluştu." });
            }
        }
        // GET: Makale
        public ActionResult Index(string aramaOlayi = null)
        {
            var makaleler = ctx.Makale.OrderByDescending(x => x.Tarih).ToList();
            if (!string.IsNullOrEmpty(aramaOlayi))
            {
                makaleler = makaleler.Where(x => x.Baslik.Contains(aramaOlayi)).ToList();
            }
            return View(makaleler);
        }

        // GET: Makale/Details/5
        public ActionResult Details(int id)
        {
            var makale = ctx.Makale.FirstOrDefault(x => x.Id == id);
            if (makale != null)
            {
                return View(makale);

            }
            return HttpNotFound("Boyle bir makale bulunmamaktadir.");
        }

        // GET: Makale/Create
        public ActionResult Create()
        {
            ViewBag.kategoriler = new SelectList(ctx.Kategori, "Id", "Ad");
            return View();
        }

        // POST: Makale/Create
        [HttpPost]
        public ActionResult Create(Makale makale, string Etiket)
        {
            try
            {
                if (makale.Icerik == null || makale.Baslik == null || makale.KategoriID == 0)
                {
                    TempData["makaleHata"] = "Makale içeriği veya başlığı boş geçilemez.";
                    return RedirectToAction("Create");
                }
                var aktifKullanici = (Kullanici)Session["aktifKullanici"];
                makale.KullaniciID = aktifKullanici.Id;

                ctx.Makale.Add(makale);


                //var makaleID = ctx.Makale.FirstOrDefault(x => x.Baslik == makale.Baslik).Id;
                var etiketListesi = Etiket.Split(',').ToList();
                foreach (var item in etiketListesi)
                {
                    var etiketim = new Etiket();
                    etiketim.Ad = item;
                    ctx.Etiket.Add(etiketim);
                    makale.Etiket.Add(etiketim);



                }
                ctx.SaveChanges();
                // TODO: Add insert logic here
                TempData["makaleBasari"] = "Makale ekleme işleminiz başarıyla tamamlandı.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["makaleHata"] = "Makale içeriği veya başlığı boş geçilemez.";
                return RedirectToAction("Create");
            }
        }

        // GET: Makale/Edit/5
        public ActionResult Edit(int id)
        {
            var aktifKullanici = (Kullanici)Session["aktifKullanici"];
            //Şuanki kullanıcı editlemek istemıyorsa yada admin degilse

            var makale = ctx.Makale.FirstOrDefault(x => x.Id == id);
            if (makale == null)
            {
                return HttpNotFound("Böyle bir makale bulunmamaktadir.");
            }

            var makaleyiYazanID = makale.KullaniciID;

            if (AdminAyrimi.EditeIzinVarmi(aktifKullanici, makaleyiYazanID))
            {
                ViewBag.kategoriler = new SelectList(ctx.Kategori, "Id", "Ad");

                return View(makale);
            }
            return HttpNotFound("Bu sayfaya erisim hakkiniz bulunmamaktadir.");
        }

        // POST: Makale/Edit/5
        [HttpPost]
        public ActionResult Edit(Makale temp)
        {
            try
            {
                ctx.Makale.AddOrUpdate(temp);
                ctx.SaveChanges();

                TempData["makaleOlayi"] = "Makale güncelleme işlemi başarıyla tamamlandı.";
                return RedirectToAction("Edit", temp.Id);
            }
            catch
            {
                TempData["makaleSorun"] = "Hata oluştu lütfen tekrar deneyiniz.";
                return RedirectToAction("Edit", temp.Id);
            }
        }

        // GET: Makale/Delete/5
        public ActionResult Delete(int id)
        {
            var aktifKullanici = (Kullanici)Session["aktifKullanici"];
            var makale = ctx.Makale.FirstOrDefault(x => x.Id == id);
            if (makale == null)
            {
                return HttpNotFound("Boyle bir makale bulunmamaktadir.");

            }

            if (AdminAyrimi.DeleteIzinVarmi(aktifKullanici, makale.KullaniciID))
            {
                return View(makale);
            }
            return HttpNotFound("Buraya erisim hakkiniz yok.");


        }

        // POST: Makale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Makale temp)
        {
            try
            {

                var makale = ctx.Makale.FirstOrDefault(x => x.Id == id);
                if (makale == null)
                {
                    return HttpNotFound("Boyle bir makale bulunmamaktadir.");
                }
                //BURADA ONCE BU MAKALENIN YORUMLARINI SILMELIYIZ
                var yorumlar = ctx.Yorum.Where(x => x.MakaleID == id);
                ctx.Yorum.RemoveRange(yorumlar);
                ctx.SaveChanges();

                //VE ETIKETLERINI DE SİLECEGIZ
                //COKA COK BIR TABLO OLDUGU ICIN USTTEKI GIBI OLMUYOR!!!
                foreach (var item in makale.Etiket)
                {
                    ctx.Etiket.Remove(item);

                }
                ctx.SaveChanges();


                ctx.Makale.Remove(makale);
                ctx.SaveChanges();
                TempData["makaleSilOlayi"] = "Makale silme işlemi başarıyla tamamlandı.";

                return RedirectToAction("Index", "Makale");
            }
            catch
            {
                TempData["makaleSilSorunu"] = "Makale silme işlemi başarısız.";
                return RedirectToAction("Delete", id);
            }
        }

        public ActionResult MakaleListele()
        {
            var aktifKullanici = (Kullanici)Session["aktifKullanici"];
            var makaleler = ctx.Makale.Where(x => x.KullaniciID == aktifKullanici.Id);
            return View(makaleler);
        }
    }
}

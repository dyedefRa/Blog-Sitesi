using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.UI.Models;

namespace Blog.UI.App_Classes
{
    public class AdminAyrimi
    {
        //Edit'e admin ve super admin sahipken
        //Delete'ye sadece super admin sahip olsun

        public static bool EditeIzinVarmi(Kullanici aktifKullanici, int duzenlenecekKullaniciID)
        {

            if (aktifKullanici.YetkiID > 2)
            {
                return true;
            }
            else if (aktifKullanici.Id == duzenlenecekKullaniciID)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteIzinVarmi(Kullanici aktifKullanici, int silinecekProfilID)
        {
            //SuperAdmin ise
            if (aktifKullanici.YetkiID > 3)
            {
                return true;
            }
            else if (aktifKullanici.Id == silinecekProfilID)
            {
                return true;
            }

            return false;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.UI.App_Classes
{
    public  class Extreme
    {
        public static string YaziKarakterSinirlandirma(string yazi,int MaxLength)
        {
            if (yazi.Length > MaxLength)
            {
                string deger = yazi.Substring(0, MaxLength);
                return deger + "...";
            }
            else
                return yazi;
        }
    }
}
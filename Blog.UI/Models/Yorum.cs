namespace Blog.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public Yorum()
        {
            this.Tarih = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        public string Icerik { get; set; }

        public int KullaniciID { get; set; }

        public int MakaleID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Tarih { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Makale Makale { get; set; }
    }
}

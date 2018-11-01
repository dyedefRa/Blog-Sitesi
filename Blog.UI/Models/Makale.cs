namespace Blog.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Makale")]
    public partial class Makale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makale()
        {
            Yorum = new HashSet<Yorum>();
            Etiket = new HashSet<Etiket>();
            this.Tarih = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Baslik { get; set; }

        [Required]
        public string Icerik { get; set; }

        public int KullaniciID { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name ="Olusturulma Tarihi:")]
        public DateTime Tarih { get; set; }

        public int KategoriID { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiket> Etiket { get; set; }
    }
}

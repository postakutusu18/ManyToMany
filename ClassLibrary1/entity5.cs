using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{

    public class Yazar
    {
        [Key]
        public int Id { get; set; }
        public string TcKimlikNo { get; set; }
        public string YazarAdi { get; set; }
        public ICollection<YazarKitap> YazarKitap { get; set; }

    }


    public class Kitap
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string KitapAdi { get; set; }
        public ICollection<YazarKitap> YazarKitap { get; set; }
    }
    public class YazarKitap
    {
        [Key]
        public int Id { get; set; }
        public string TcKimlikNo { get; set; }
        public Yazar Yazar { get; set; }
        public string ISBN { get; set; }
      public Kitap Kitap { get; set; }
    }
    
}

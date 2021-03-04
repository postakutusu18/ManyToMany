using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary3
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string MenuCode { get; set; }
        public Route Route { get; set; }
    }

    public class Route
    {
        [Key]
        public int Id { get; set; }
        public string MenuCode { get; set; }
        public string Name { get; set; }
        public Menu Menu { get; set; }
    }
}

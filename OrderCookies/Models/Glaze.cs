using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class Glaze
    {
        //ID глазури
        [Key]
        public int GlazeId { get; set; }
        //Наименование глазури
        public string GlazeName { get; set; }
        //Цена за 100 гр.
        public int GlazePrice { get; set; }
    }
}
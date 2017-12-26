using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class SpecialDesign
    {
        //ID 
        [Key]
        public int SpecialDesignId { get; set; }
        //Наименование
        public string Design { get; set; }
        //Цена
        public int DesignPrice { get; set; }
    }
}
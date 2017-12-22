using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class CookieSize
    {
        //ID размера
        [Key]
        public int CookieSizeId { get; set; }
        //Размер
        public int Size { get; set; }
    }
}
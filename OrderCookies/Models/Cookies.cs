using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace OrderCookies.Models
{
    public class Cookies
    {
        //ID печенья
        [Key]
        public int CookiesId { get; set; }
        //Название печенья
        public string CookiesName { get; set; }
        //Форма печенья
        public int CookieFormId { get; set; }
        public CookieForm CookieForm { get; set; }
        //Размер печенья
        public int CookieSizeId { get; set; }
        public CookieSize CookieSize { get; set; }
        //Тесто для изготовления печенья
        public int PastryId { get; set; }
        public Pastry Pastry { get; set; }
        //Начинка
        public int FillingId { get; set; }
        public Filling Filling { get; set; }
        //Глазурь
        public int? GlazeId { get; set; }
        public Glaze Glaze { get; set; }
        //Специальное оформление
        public int? SpecialDesignId { get; set; }
        public SpecialDesign SpecialDesign { get; set; }
        //Примечания
        public string Comments { get; set; }
        //Цена печенья (за 1 шт)
        public int Price { get; set; }
    }
}
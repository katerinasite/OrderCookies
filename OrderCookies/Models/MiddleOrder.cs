using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class MiddleOrder
    {
        //ID промежуточного заказа
        [Key]
        public int MiddleOrderId { get; set; }
        //Ссылка на итоговый заказ
        public int FinalOrderId { get; set; }
        public FinalOrder FinalOrder { get; set; }
        //Заказанное печенье
        public int CookiesId { get; set; }
        public Cookies Cookies { get; set; }
        //Количество заказанных печенек
        public int Number { get; set; }
        //Стоимость промежуточного заказа
        public int MiddleAmount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class FinalOrder
    {
        //ID итогового заказа
        [Key]
        public int FinalOrderId { get; set; }
        //ID пользователя
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }        
        //Общая стоимость заказа
        public int FinalAmount { get; set; }
        //Дата получения заказа
        public DateTime Date { get; set; }
        //Статус заказа
        public bool IsConfirmed { get; set; }
    }
}
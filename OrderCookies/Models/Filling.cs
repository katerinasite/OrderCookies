using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class Filling
    {
        //ID начинки
        [Key]
        public int FillingId { get; set; }
        //Наименование начинки
        public string FillingName { get; set; }
        //Цена за 100 гр.
        public int FillingPrice { get; set; }
    }
}
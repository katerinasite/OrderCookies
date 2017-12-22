using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class Pastry
    {
        //ID теста
        [Key]
        public int PastryId { get; set; }
        //Наименование теста
        public string PastryName { get; set; }
    }
}
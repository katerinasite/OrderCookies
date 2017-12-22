using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderCookies.Models
{
    public class CookieForm
    {
        //ID формы
        [Key]
        public int CookieFormId { get; set; }
        //Название формы
        public string CookieFormName { get; set; }
        //Примечание
        public string CookieDescription { get; set; }
    }
}
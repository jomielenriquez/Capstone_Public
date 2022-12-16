using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPSTONE.Models
{
    public class Menu
    {
        public string Text { get; set; }
        public string icon { get; set; }
        public string tagid { get; set; }
        public string action { get; set; }
        public string controller { get; set; }
    }
    public class CurrentUser
    {
        public string fullname { get; set; }
        public string acnttype { get; set; }
        public string uid { get; set; }
    }
    public class UserControl
    {
        public CurrentUser currentuser { get; set; }
        public List<Menu> menulist { get; set; }
    }
}
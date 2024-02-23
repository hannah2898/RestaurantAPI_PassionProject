using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI_PassionProject.Models.ViewModels
{
    public class DetailsMenu
    {
        public MenuDto selectedmenu { get; set; }
        public MenuDto selectedcategory { get; internal set; }
        public IEnumerable<MenuDto> Menus { get; set; }
        public DetailsMenu()
        {
            // Initialize Menus property to an empty list
            Menus = new List<MenuDto>();
        }
    }
}
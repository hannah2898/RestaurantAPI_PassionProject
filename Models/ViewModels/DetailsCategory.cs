using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI_PassionProject.Models.ViewModels
{
    public class DetailsCategory
    {
        public CategoryDto selectedcategory {  get; set; }
        public IEnumerable<MenuDto> Menus { get; set; }
        public DetailsCategory()
        {
            // Initialize Menus property to an empty list
            Menus = new List<MenuDto>();
        }
    }

}
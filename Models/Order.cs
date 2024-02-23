using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RestaurantAPI_PassionProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TableNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        //An order can have many menu items
        public ICollection<Menu> Menus { get; set; }
    }
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int TableNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
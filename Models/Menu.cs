﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantAPI_PassionProject.Models
{
    public class Menu
    {
        //fields for the Menu
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        //price is in CAD
        public double Price { get; set; }
        public int Quantity { get; set; }

        //A menu item will belong to a category
        //An category can have any menu items
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


        //a menu can be in many orders
        public ICollection<Order> Orders { get; set; }
    }
    public class MenuDto
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
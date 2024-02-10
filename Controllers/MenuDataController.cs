using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantAPI_PassionProject.Models;

namespace RestaurantAPI_PassionProject.Controllers
{
    /// <summary>
    /// Controller for managing menu data through API endpoints.
    /// </summary>
    public class MenuDataController : ApiController
    {
        // Utilizing database connection
        private ApplicationDbContext db = new ApplicationDbContext();

        // List MenuItem
        // GET: api/MenuData/ListMenu
        /// <summary>
        /// Retrieves a list of menu items.
        /// </summary>
        /// <returns>A list of menu items.</returns>
        [HttpGet]
        [Route("api/MenuData/ListMenu")]
        public IEnumerable<MenuDto> ListMenu()
        {
            // Sending a query to the database
            List<Menu> Menus = db.Menus.ToList();

            List<MenuDto> MenuDtos = new List<MenuDto>();
            Menus.ForEach(b => MenuDtos.Add(new MenuDto()
            {
                ItemID = b.ItemID,
                ItemName = b.ItemName,
                ItemDescription = b.ItemDescription,
                Price = b.Price,
                CategoryName = b.Category.CategoryName
            }
            ));

            // Read
            return MenuDtos;
        }

        // Find MenuItem
        // Get: api/MenuData/FindMenuItem/{id}
        /// <summary>
        /// Finds a specific menu item by its ID.
        /// </summary>
        /// <param name="id">The ID of the menu item to find.</param>
        /// <returns>The menu item with the specified ID.</returns>
        [ResponseType(typeof(Menu))]
        [HttpGet]
        public IHttpActionResult FindMenuItem(int id)
        {
            Menu Menu = db.Menus.Find(id);
            MenuDto MenuDto = new MenuDto()
            {
                ItemID = Menu.ItemID,
                ItemName = Menu.ItemName,
                ItemDescription = Menu.ItemDescription,
                Price = Menu.Price,
                CategoryName = Menu.Category.CategoryName
            };
            if (Menu == null)
            {
                return NotFound();
            }

            return Ok(MenuDto);
        }

        // Add MenuItem
        // POST: api/MenuData/AddMenuItem
        /// <summary>
        /// Adds a new menu item to the database.
        /// </summary>
        /// <param name="menu">The menu item to add.</param>
        /// <returns>The added menu item.</returns>
        [ResponseType(typeof(Menu))]
        [HttpPost]
        public IHttpActionResult AddMenuItem(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menus.Add(menu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menu.ItemID }, menu);
        }

        // Update MenuItem
        // POST: api/MenuData/Update/5
        /// <summary>
        /// Updates an existing menu item in the database.
        /// </summary>
        /// <param name="id">The ID of the menu item to update.</param>
        /// <param name="menu">The updated menu item.</param>
        /// <returns>No content.</returns>
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Update(int id, Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.ItemID)
            {
                return BadRequest();
            }

            db.Entry(menu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // Delete MenuItem
        // POST: api/MenuData/DeleteMenuItem/5
        /// <summary>
        /// Deletes a menu item from the database.
        /// </summary>
        /// <param name="id">The ID of the menu item to delete.</param>
        /// <returns>OK if successful.</returns>
        [ResponseType(typeof(Menu))]
        [HttpPost]
        [Route("api/MenuData/DeleteMenuItem/{id}")]
        public IHttpActionResult DeleteMenuItem(int id)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            db.Menus.Remove(menu);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(int id)
        {
            return db.Menus.Count(e => e.ItemID == id) > 0;
        }
    }
}

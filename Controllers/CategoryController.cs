using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Mvc;
using RestaurantAPI_PassionProject.Models.ViewModels;
using RestaurantAPI_PassionProject.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace RestaurantAPI_PassionProject.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static CategoryController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44361/api/categorydata/");
        }

        // GET: Category/List
        public ActionResult List()
        {
            // Retrieve a list of categories from the Category data API
            string url = "ListCategory";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<CategoryDto> categories = response.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;
            return View(categories);
        }

        // GET: Category/Error
        public ActionResult Error()
        {
            return View();
        }

        // GET: Category/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            // Add a new category to the Category data
            string url = "AddCategory";
            string jsonPayload = jss.Serialize(category);

            HttpContent content = new StringContent(jsonPayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
      
        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            // Get details of a specific category item
            DetailsMenu ViewModel = new DetailsMenu();
            string url = "ListMenuItemsForCategory/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            var selectedCategory = JsonConvert.DeserializeObject<IEnumerable<MenuDto>> (responseContent);
            var menus = JsonConvert.DeserializeObject<IEnumerable<MenuDto>>(responseContent);

            ViewModel.selectedcategory = selectedCategory.FirstOrDefault();
            ViewModel.Menus = menus;
            Debug.WriteLine("Response Content"+responseContent);
            return View(ViewModel);
        }
    

        // GET: Category/DeleteConfirm/5
        public ActionResult DeleteConfirm(int id)
        {
            // Retrieve category details for deletion confirmation
            string url = "FindCategory/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CategoryDto selectedCategory = response.Content.ReadAsAsync<CategoryDto>().Result;

            return View(selectedCategory);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Delete a category
            string url = "DeleteCategory/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}

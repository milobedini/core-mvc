using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_mvc_web.Data;
using core_mvc_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace core_mvc_web.Controllers
{
    public class CategoryController : Controller
    {
        //Access the category db via the application context we created (dependency injection).
        private readonly ApplicationDbContext _db;

        //Constructor
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //GET for add category view
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        //above is for CSRF
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
    }
}
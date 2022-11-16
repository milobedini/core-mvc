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

        //Constructor where you create the DB object
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //GET for add category view. The create page basically.Returns the cat view.
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            //Alternative methods:
            //var categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDb = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            //Alternative methods:
            //var categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDb = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST for add category action.Changes DB and then redirects.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //above is for CSRF
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //By using the key of Name, the error will be associated with the name input.
                //This is linked using the tag helpers in the Create (view) file.
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
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

        //Edit is also a post.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //By using the key of Name, the error will be associated with the name input.
                //This is linked using the tag helpers in the Create (view) file.
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {

            if (obj != null)
            {
                _db.Categories.Remove(obj);
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
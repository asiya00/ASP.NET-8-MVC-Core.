using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Category()
        {
            List<Category> dbCategoryList = _db.Categories.ToList();
            return View(dbCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //property related custom error generation
            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName", "The Name can't be same as Display Order.");
            }

            //model related error validation
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Category");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            Category? category = _db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //property related custom error generation
            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName", "The Name can't be same as Display Order.");
            }

            //model related error validation
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Category");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Category");
        }
    }
}

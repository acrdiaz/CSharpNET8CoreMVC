﻿using CSharpNET8CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpNET8CoreMVC.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";

            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(category);
        }
        
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            CategoriesRepository.UpdateCategory(category.Id, category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            CategoriesRepository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            CategoriesRepository.DeleteCategory(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

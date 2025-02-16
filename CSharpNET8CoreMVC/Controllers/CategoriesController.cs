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
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            CategoriesRepository.UpdateCategory(category.Id, category);
            return RedirectToAction(nameof(Index));
        }
    }
}

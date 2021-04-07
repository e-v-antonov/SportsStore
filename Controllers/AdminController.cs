﻿using SportsStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    /// <summary>
    /// Класс контроллера для управления каталогом товаров
    /// </summary>
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));
    
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";

                return RedirectToAction("Index");
            }
            else
            {
                //Что-то не твк со значениями данных
                return View(product);
            }
        }
    }
}
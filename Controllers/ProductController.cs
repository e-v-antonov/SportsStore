using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="repo">Будут передоваться данные фиктивного хранилища</param>
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Визуализация стандартного представления
        /// </summary>
        /// <returns></returns>
        public ViewResult List() => View(repository.Products);
    }
}

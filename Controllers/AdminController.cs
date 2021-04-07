using SportsStore.Models;
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
    
        
    }
}

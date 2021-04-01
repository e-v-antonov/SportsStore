using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

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
        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize) //пропускаем товары до начала выбранной странницы
                .Take(PageSize),    //выбираем количество товаров

                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },

                CurrentCategory = category
            });
    }
}

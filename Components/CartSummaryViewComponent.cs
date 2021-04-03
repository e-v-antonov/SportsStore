using SportsStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Components
{
    /// <summary>
    /// Класс компонента представления, который передает объект Cart методу View
    /// чтобы сгенерировать фрагмент HTML-разметки для включения в копоновку
    /// </summary>
    public class CartSummaryViewComponent : ViewComponent 
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}

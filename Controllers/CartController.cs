using System.Linq;
using SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportsStore.Infrastructure;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    /// <summary>
    /// Класс контроллера для корзины покупок
    /// </summary>
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl) => View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            //TODO: Вынести в отдельный метод повторяющиеся куски кода 
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string  returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId); 

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}

using SportsStore.Models;

namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// Класс модели представления для передачи данных о товарах в корзине покупок и URL
    /// </summary>
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}

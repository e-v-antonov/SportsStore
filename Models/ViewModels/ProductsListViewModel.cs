using System.Collections.Generic;
using SportsStore.Models;

namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// Класс,который содержит данные для передачи из контроллера в представление
    /// </summary>
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}

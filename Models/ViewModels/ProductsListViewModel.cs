using System.Collections.Generic;
using SportsStore.Models;

namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// Класс модели представления для передачи данных о списке товаров
    /// </summary>
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}

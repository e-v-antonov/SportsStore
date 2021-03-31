using System;

namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// Класс модели представления для информации о кол-ве страниц,
    /// текущей странице и общем числе товаров в хранилище
    /// </summary>
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}

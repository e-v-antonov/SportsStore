using System.Linq;

namespace SportsStore.Models
{
    /// <summary>
    /// Получение объектов Order и сохранение их
    /// </summary>
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);
    }
}

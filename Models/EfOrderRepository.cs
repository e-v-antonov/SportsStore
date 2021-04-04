using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class EfOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EfOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines) //должна загружаться коллекция ассоциированная со свойствм Lines
            .ThenInclude(l => l.Product);   //наряду с объектами Product которые связаны с элементами коллекции

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));    //объекты не должны сохраняться пока они не будут модифицированы

            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}

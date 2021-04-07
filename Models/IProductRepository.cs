using System.Linq;

namespace SportsStore.Models
{
    /// <summary>
    /// Получение объектов Product
    /// </summary>
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    /// <summary>
    /// Модель товара
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}

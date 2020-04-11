using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public double Price { get; set; }

        public short Quantity { get; set; }

        public string ImagePath { get; set; }

        public string ResizedImagePath { get; set; }

        public Gender Gender { get; set; }

        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }

        [ForeignKey("Category")]
        public short CategoryId { get; set; }

        [ForeignKey("Brand")]
        public short BrandId { get; set; }
    }

    public enum Gender
    {
        Boys = 1,
        Girls = 2,
        All = 3
    }
}

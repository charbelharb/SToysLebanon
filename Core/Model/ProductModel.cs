using Data;

namespace Core.Model
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public double Price { get; set; }

        public short Quantity { get; set; }

        public string ImagePath { get; set; }

        public string ResizedImagePath { get; set; }

        public Gender Gender { get; set; }
    }
}

namespace Core.Model
{
    public class ProductSearchModel : PaginatorModel
    {
        public int Gender { get; set; }

        public short Category { get; set; }

        public int SortBy { get; set; }

        public int Direction { get; set; }

        public string SearchText { get; set; }

        public short Brand { get; set; }


    }
}
